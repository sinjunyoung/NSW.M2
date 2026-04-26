using System.Collections.Generic;

namespace LibHac.Tools.FsSystem.Save;

public static class SaveExtensions
{
    public static IEnumerable<(int block, int length)> DumpChain(this AllocationTable table, int startBlock)
    {
        AllocationTableIterator iterator = new(table, startBlock);

        do
        {
            yield return (iterator.PhysicalBlock, iterator.CurrentSegmentSize);
        } while (iterator.MoveNext());
    }
}