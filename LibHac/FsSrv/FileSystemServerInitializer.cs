using System;
using LibHac.Common;
using LibHac.Fs.Impl;
using LibHac.Fs.Shim;
using LibHac.FsSrv.FsCreator;
using LibHac.FsSrv.Impl;
using LibHac.FsSrv.Sf;
using LibHac.FsSrv.Storage;
using LibHac.FsSystem;
using LibHac.Sm;

namespace LibHac.FsSrv;

public static class FileSystemServerInitializer
{
    private const ulong SpeedEmulationProgramIdWithoutPlatformIdMinimum = 0;
    private const ulong SpeedEmulationProgramIdWithoutPlatformIdMaximum = 0x1FFF;

    private const uint ContentDivisionSize = ConcatenationFileSystem.DefaultInternalFileSize;

    private const int BufferManagerHeapSize = 1024 * 1024 * 14;
    private const int BufferManagerCacheSize = 1024;
    private const int BufferManagerBlockSize = 0x4000;

    /// <summary>
    /// Initializes a <see cref="FileSystemServer"/> with the provided <see cref="FileSystemServerConfig"/>.
    /// </summary>
    /// <param name="client">The <see cref="HorizonClient"/> that <paramref name="server"/> was created with.</param>
    /// <param name="server">The <see cref="FileSystemServer"/> to initialize.</param>
    /// <param name="config">The config for initializing <paramref name="server"/>.</param>
    public static void InitializeWithConfig(HorizonClient client, FileSystemServer server, FileSystemServerConfig config)
    {
        if (config.FsCreators == null)
            throw new ArgumentException("FsCreators must not be null");

        if (config.StorageDeviceManagerFactory == null)
            throw new ArgumentException("StorageDeviceManagerFactory must not be null");

        server.SetDebugFlagEnabled(false);
        server.Storage.InitializeStorageDeviceManagerFactory(config.StorageDeviceManagerFactory);

        FileSystemProxyConfiguration fspConfig = InitializeFileSystemProxy(server, config);

        using SharedRef<IFileSystemProxy> fileSystemProxy = server.Impl.GetFileSystemProxyServiceObject();
        ulong processId = client.Os.GetCurrentProcessId().Value;
        fileSystemProxy.Get.SetCurrentProcess(processId).IgnoreResult();

        client.Fs.Impl.InitializeDfcFileSystemProxyServiceObject(in fileSystemProxy);

        InitializeFileSystemProxyServer(client, server);

        using SharedRef<SaveDataFileSystemService> saveService = SaveDataFileSystemService.CreateShared(fspConfig.SaveDataFileSystemService, processId);

        saveService.Get.CleanUpTemporaryStorage().IgnoreResult();
        saveService.Get.CleanUpSaveData().IgnoreResult();
        saveService.Get.CompleteSaveDataExtension().IgnoreResult();
        saveService.Get.FixSaveData().IgnoreResult();
        saveService.Get.RecoverMultiCommit().IgnoreResult();

        config.StorageDeviceManagerFactory.SetReady(StorageDevicePortId.SdCard, null);
        config.StorageDeviceManagerFactory.SetReady(StorageDevicePortId.GameCard, null);

        // NS usually takes care of this
        if (client.Fs.IsSdCardInserted())
            client.Fs.SetSdCardAccessibility(true);
    }

    private static FileSystemProxyConfiguration InitializeFileSystemProxy(FileSystemServer server,
        FileSystemServerConfig config)
    {
        FileSystemBufferManager bufferManager = new();
        Memory<byte> heapBuffer = GC.AllocateArray<byte>(BufferManagerHeapSize, true);
        bufferManager.Initialize(BufferManagerCacheSize, heapBuffer, BufferManagerBlockSize);

        // Todo: Assign based on the value of "IsDevelopment"
        DebugConfigurationServiceImpl.Configuration debugConfigurationServiceConfig = new();
        debugConfigurationServiceConfig.IsDisabled = false;
        DebugConfigurationServiceImpl debugConfigurationService = new(in debugConfigurationServiceConfig);

        SaveDataIndexerManager saveDataIndexerManager = new(server.Hos.Fs, Fs.SaveData.SaveIndexerId,
            new ArrayPoolMemoryResource(), new SdHandleManager(server), false);

        ProgramRegistryServiceImpl.Configuration programRegistryConfig = new();
        programRegistryConfig.FsServer = server;

        ProgramRegistryServiceImpl programRegistryService = new(in programRegistryConfig);

        ProgramRegistryImpl.Initialize(server, programRegistryService);

        BaseStorageServiceImpl.Configuration baseStorageConfig = new();
        baseStorageConfig.BisStorageCreator = config.FsCreators.BuiltInStorageCreator;
        baseStorageConfig.GameCardStorageCreator = config.FsCreators.GameCardStorageCreator;
        baseStorageConfig.FsServer = server;
        BaseStorageServiceImpl baseStorageService = new(in baseStorageConfig);

        TimeServiceImpl timeService = new(server);

        BaseFileSystemServiceImpl.Configuration baseFsServiceConfig = new();
        baseFsServiceConfig.BisFileSystemCreator = config.FsCreators.BuiltInStorageFileSystemCreator;
        baseFsServiceConfig.GameCardFileSystemCreator = config.FsCreators.GameCardFileSystemCreator;
        baseFsServiceConfig.SdCardFileSystemCreator = config.FsCreators.SdCardFileSystemCreator;
        baseFsServiceConfig.BisWiperCreator = BisWiper.CreateWiper;
        baseFsServiceConfig.FsServer = server;
        BaseFileSystemServiceImpl baseFsService = new(in baseFsServiceConfig);

        AccessFailureManagementServiceImpl.Configuration accessFailureManagementServiceConfig = new();
        accessFailureManagementServiceConfig.FsServer = server;

        AccessFailureManagementServiceImpl accessFailureManagementService = new(in accessFailureManagementServiceConfig);

        InternalProgramIdRangeForSpeedEmulation speedEmulationRange =
            new(SpeedEmulationProgramIdWithoutPlatformIdMinimum,
                SpeedEmulationProgramIdWithoutPlatformIdMaximum);

        NcaFileSystemServiceImpl.Configuration ncaFsServiceConfig = new();
        ncaFsServiceConfig.BaseFsService = baseFsService;
        ncaFsServiceConfig.LocalFsCreator = config.FsCreators.LocalFileSystemCreator;
        ncaFsServiceConfig.TargetManagerFsCreator = config.FsCreators.TargetManagerFileSystemCreator;
        ncaFsServiceConfig.PartitionFsCreator = config.FsCreators.PartitionFileSystemCreator;
        ncaFsServiceConfig.RomFsCreator = config.FsCreators.RomFileSystemCreator;
        ncaFsServiceConfig.StorageOnNcaCreator = config.FsCreators.StorageOnNcaCreator;
        ncaFsServiceConfig.SubDirectoryFsCreator = config.FsCreators.SubDirectoryFileSystemCreator;
        ncaFsServiceConfig.EncryptedFsCreator = config.FsCreators.EncryptedFileSystemCreator;
        ncaFsServiceConfig.ProgramRegistryService = programRegistryService;
        ncaFsServiceConfig.AccessFailureManagementService = accessFailureManagementService;
        ncaFsServiceConfig.SpeedEmulationRange = speedEmulationRange;
        ncaFsServiceConfig.AddOnContentDivisionSize = ContentDivisionSize;
        ncaFsServiceConfig.RomDivisionSize = ContentDivisionSize;
        ncaFsServiceConfig.FsServer = server;

        NcaFileSystemServiceImpl ncaFsService = new(in ncaFsServiceConfig);

        SaveDataFileSystemServiceImpl.Configuration saveFsServiceConfig = new();
        saveFsServiceConfig.BaseFsService = baseFsService;
        saveFsServiceConfig.TimeService = timeService;
        saveFsServiceConfig.LocalFsCreator = config.FsCreators.LocalFileSystemCreator;
        saveFsServiceConfig.TargetManagerFsCreator = config.FsCreators.TargetManagerFileSystemCreator;
        saveFsServiceConfig.SaveFsCreator = config.FsCreators.SaveDataFileSystemCreator;
        saveFsServiceConfig.EncryptedFsCreator = config.FsCreators.EncryptedFileSystemCreator;
        saveFsServiceConfig.ProgramRegistryService = programRegistryService;
        saveFsServiceConfig.BufferManager = bufferManager;
        saveFsServiceConfig.GenerateRandomData = config.RandomGenerator;
        saveFsServiceConfig.IsPseudoSaveData = () => true;
        saveFsServiceConfig.SaveDataFileSystemCacheCount = 1;
        saveFsServiceConfig.SaveIndexerManager = saveDataIndexerManager;
        saveFsServiceConfig.DebugConfigService = debugConfigurationService;
        saveFsServiceConfig.JournalIntegritySaveDataVersion = 0x50000;
        saveFsServiceConfig.JournalIntegritySupportedVersionMin = 0x40000;
        saveFsServiceConfig.JournalIntegritySupportedVersionMax = 0x50000;
        saveFsServiceConfig.IntegritySaveDataVersion = 0x10000;
        saveFsServiceConfig.IntegritySupportedVersionMin = 0x10000;
        saveFsServiceConfig.IntegritySupportedVersionMax = 0x10000;
        saveFsServiceConfig.FsServer = server;

        SaveDataFileSystemServiceImpl saveFsService = new(in saveFsServiceConfig);

        StatusReportServiceImpl.Configuration statusReportServiceConfig = new();
        statusReportServiceConfig.NcaFileSystemServiceImpl = ncaFsService;
        statusReportServiceConfig.SaveDataFileSystemServiceImpl = saveFsService;
        statusReportServiceConfig.BufferManagerMemoryReport = null;
        statusReportServiceConfig.ExpHeapMemoryReport = null;
        statusReportServiceConfig.BufferPoolMemoryReport = null;
        statusReportServiceConfig.GetPatrolAllocateCounts = null;
        statusReportServiceConfig.MainThreadStackUsageReporter = new DummyStackUsageReporter();
        statusReportServiceConfig.IpcWorkerThreadStackUsageReporter = new DummyStackUsageReporter();
        statusReportServiceConfig.PipeLineWorkerThreadStackUsageReporter = new DummyStackUsageReporter();
        statusReportServiceConfig.FsServer = server;

        StatusReportServiceImpl statusReportService = new(in statusReportServiceConfig);

        AccessLogServiceImpl.Configuration accessLogServiceConfig = new();
        accessLogServiceConfig.MinimumProgramIdForSdCardLog = 0x0100000000003000;
        accessLogServiceConfig.FsServer = server;

        AccessLogServiceImpl accessLogService = new(in accessLogServiceConfig);

        FileSystemProxyConfiguration fspConfig = new()
        {
            FsCreatorInterfaces = config.FsCreators,
            BaseStorageService = baseStorageService,
            BaseFileSystemService = baseFsService,
            NcaFileSystemService = ncaFsService,
            SaveDataFileSystemService = saveFsService,
            AccessFailureManagementService = accessFailureManagementService,
            TimeService = timeService,
            StatusReportService = statusReportService,
            ProgramRegistryService = programRegistryService,
            AccessLogService = accessLogService,
            DebugConfigurationService = debugConfigurationService
        };

        server.InitializeFileSystemProxy(fspConfig);
        return fspConfig;
    }

    private static void InitializeFileSystemProxyServer(HorizonClient client, FileSystemServer server)
    {
        client.Sm.RegisterService(new FileSystemProxyService(server), "fsp-srv").IgnoreResult();
        client.Sm.RegisterService(new FileSystemProxyForLoaderService(server), "fsp-ldr").IgnoreResult();
        client.Sm.RegisterService(new ProgramRegistryService(server), "fsp-pr").IgnoreResult();
    }

    private class FileSystemProxyService : IServiceObject
    {
        private readonly FileSystemServer _server;

        public FileSystemProxyService(FileSystemServer server)
        {
            _server = server;
        }

        public Result GetServiceObject(ref SharedRef<IDisposable> outServiceObject)
        {
            using SharedRef<IFileSystemProxy> derivedObject = _server.Impl.GetFileSystemProxyServiceObject();
            outServiceObject.SetByMove(ref derivedObject.Ref);
            return Result.Success;
        }

        public void Dispose() { }
    }

    private class FileSystemProxyForLoaderService : IServiceObject
    {
        private readonly FileSystemServer _server;

        public FileSystemProxyForLoaderService(FileSystemServer server)
        {
            _server = server;
        }

        public Result GetServiceObject(ref SharedRef<IDisposable> outServiceObject)
        {
            using SharedRef<IFileSystemProxyForLoader> derivedObject = _server.Impl.GetFileSystemProxyForLoaderServiceObject();
            outServiceObject.SetByMove(ref derivedObject.Ref);
            return Result.Success;
        }

        public void Dispose() { }
    }

    private class ProgramRegistryService : IServiceObject
    {
        private readonly FileSystemServer _server;

        public ProgramRegistryService(FileSystemServer server)
        {
            _server = server;
        }

        public Result GetServiceObject(ref SharedRef<IDisposable> outServiceObject)
        {
            using SharedRef<IProgramRegistry> derivedObject = _server.Impl.GetProgramRegistryServiceObject();
            outServiceObject.SetByMove(ref derivedObject.Ref);
            return Result.Success;
        }

        public void Dispose() { }
    }

    private class DummyStackUsageReporter : IStackUsageReporter
    {
        public uint GetStackUsage() => 0;
    }
}

/// <summary>
/// Contains the configuration for creating a new <see cref="FileSystemServer"/>.
/// </summary>
public class FileSystemServerConfig
{
    /// <summary>
    /// The <see cref="FileSystemCreatorInterfaces"/> used for creating filesystems.
    /// </summary>
    public FileSystemCreatorInterfaces FsCreators { get; set; }

    /// <summary>
    /// An <see cref="IStorageDeviceManagerFactory"/> for managing the gamecard and SD card.
    /// </summary>
    public IStorageDeviceManagerFactory StorageDeviceManagerFactory { get; set; }

    /// <summary>
    /// A keyset containing rights IDs and title keys.
    /// If null, an empty set will be created.
    /// </summary>
    public ExternalKeySet ExternalKeySet { get; set; }

    /// <summary>
    /// Used for generating random data for save data.
    /// </summary>
    public RandomDataGenerator RandomGenerator { get; set; }
}