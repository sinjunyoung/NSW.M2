namespace LibHac.Os;

public readonly struct ProcessId
{
    public static ProcessId InvalidId => new(ulong.MaxValue);

    public readonly ulong Value;

    public ProcessId(ulong value) => Value = value;
}