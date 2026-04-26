using System;
using LibHac.Bcat;
using LibHac.Common.Keys;
using LibHac.Fs.Fsa;
using LibHac.FsSrv;
using LibHac.FsSystem;

namespace LibHac;

public static class HorizonFactory
{
    public static Horizon CreateWithDefaultFsConfig(HorizonConfiguration config, IFileSystem rootFileSystem,
        KeySet keySet)
    {
        Horizon horizon = new(config);

        HorizonClient fsServerClient = horizon.CreatePrivilegedHorizonClient();
        FileSystemServer fsServer = new(fsServerClient);

        Random random = new();
        RandomDataGenerator randomGenerator = buffer => random.NextBytes(buffer);

        DefaultFsServerObjects defaultObjects = DefaultFsServerObjects.GetDefaultEmulatedCreators(rootFileSystem, keySet, fsServer, randomGenerator);

        FileSystemServerConfig fsServerConfig = new()
        {
            ExternalKeySet = keySet.ExternalKeySet,
            FsCreators = defaultObjects.FsCreators,
            StorageDeviceManagerFactory = defaultObjects.StorageDeviceManagerFactory,
            RandomGenerator = randomGenerator
        };

        FileSystemServerInitializer.InitializeWithConfig(fsServerClient, fsServer, fsServerConfig);

        HorizonClient bcatServerClient = horizon.CreateHorizonClient();
        _ = new BcatServer(bcatServerClient);

        return horizon;
    }
}