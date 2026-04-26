//-----------------------------------------------------------------------------
// This file was automatically generated.
// Changes to this file will be lost when the file is regenerated.
//
// The script can be run with the "codegen" option to run only the
// code generation portion of the build.
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace LibHac.Common.FixedArrays;

[InlineArray(1)] public struct Array1<T>
{
    private T _0;
    public readonly int Length => 1;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(2)] public struct Array2<T>
{
    private T _0;
    public readonly int Length => 2;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(3)] public struct Array3<T>
{
    private T _0;
    public readonly int Length => 3;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(4)] public struct Array4<T>
{
    private T _0;
    public readonly int Length => 4;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(5)] public struct Array5<T>
{
    private T _0;
    public readonly int Length => 5;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(6)] public struct Array6<T>
{
    private T _0;
    public readonly int Length => 6;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(7)] public struct Array7<T>
{
    private T _0;
    public readonly int Length => 7;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(8)] public struct Array8<T>
{
    private T _0;
    public readonly int Length => 8;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(9)] public struct Array9<T>
{
    private T _0;
    public readonly int Length => 9;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(10)] public struct Array10<T>
{
    private T _0;
    public readonly int Length => 10;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(11)] public struct Array11<T>
{
    private T _0;
    public readonly int Length => 11;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(12)] public struct Array12<T>
{
    private T _0;
    public readonly int Length => 12;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(13)] public struct Array13<T>
{
    private T _0;
    public readonly int Length => 13;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(14)] public struct Array14<T>
{
    private T _0;
    public readonly int Length => 14;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(15)] public struct Array15<T>
{
    private T _0;
    public readonly int Length => 15;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(16)] public struct Array16<T>
{
    private T _0;
    public readonly int Length => 16;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(17)] public struct Array17<T>
{
    private T _0;
    public readonly int Length => 17;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(18)] public struct Array18<T>
{
    private T _0;
    public readonly int Length => 18;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(19)] public struct Array19<T>
{
    private T _0;
    public readonly int Length => 19;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(20)] public struct Array20<T>
{
    private T _0;
    public readonly int Length => 20;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(21)] public struct Array21<T>
{
    private T _0;
    public readonly int Length => 21;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(22)] public struct Array22<T>
{
    private T _0;
    public readonly int Length => 22;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(23)] public struct Array23<T>
{
    private T _0;
    public readonly int Length => 23;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(24)] public struct Array24<T>
{
    private T _0;
    public readonly int Length => 24;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(25)] public struct Array25<T>
{
    private T _0;
    public readonly int Length => 25;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(26)] public struct Array26<T>
{
    private T _0;
    public readonly int Length => 26;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(27)] public struct Array27<T>
{
    private T _0;
    public readonly int Length => 27;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(28)] public struct Array28<T>
{
    private T _0;
    public readonly int Length => 28;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(29)] public struct Array29<T>
{
    private T _0;
    public readonly int Length => 29;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(30)] public struct Array30<T>
{
    private T _0;
    public readonly int Length => 30;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(31)] public struct Array31<T>
{
    private T _0;
    public readonly int Length => 31;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(32)] public struct Array32<T>
{
    private T _0;
    public readonly int Length => 32;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(33)] public struct Array33<T>
{
    private T _0;
    public readonly int Length => 33;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(34)] public struct Array34<T>
{
    private T _0;
    public readonly int Length => 34;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(35)] public struct Array35<T>
{
    private T _0;
    public readonly int Length => 35;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(36)] public struct Array36<T>
{
    private T _0;
    public readonly int Length => 36;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(37)] public struct Array37<T>
{
    private T _0;
    public readonly int Length => 37;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(38)] public struct Array38<T>
{
    private T _0;
    public readonly int Length => 38;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(39)] public struct Array39<T>
{
    private T _0;
    public readonly int Length => 39;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(40)] public struct Array40<T>
{
    private T _0;
    public readonly int Length => 40;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(41)] public struct Array41<T>
{
    private T _0;
    public readonly int Length => 41;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(42)] public struct Array42<T>
{
    private T _0;
    public readonly int Length => 42;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(43)] public struct Array43<T>
{
    private T _0;
    public readonly int Length => 43;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(44)] public struct Array44<T>
{
    private T _0;
    public readonly int Length => 44;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(45)] public struct Array45<T>
{
    private T _0;
    public readonly int Length => 45;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(46)] public struct Array46<T>
{
    private T _0;
    public readonly int Length => 46;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(47)] public struct Array47<T>
{
    private T _0;
    public readonly int Length => 47;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(48)] public struct Array48<T>
{
    private T _0;
    public readonly int Length => 48;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(49)] public struct Array49<T>
{
    private T _0;
    public readonly int Length => 49;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(50)] public struct Array50<T>
{
    private T _0;
    public readonly int Length => 50;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(51)] public struct Array51<T>
{
    private T _0;
    public readonly int Length => 51;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(52)] public struct Array52<T>
{
    private T _0;
    public readonly int Length => 52;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(53)] public struct Array53<T>
{
    private T _0;
    public readonly int Length => 53;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(54)] public struct Array54<T>
{
    private T _0;
    public readonly int Length => 54;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(55)] public struct Array55<T>
{
    private T _0;
    public readonly int Length => 55;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(56)] public struct Array56<T>
{
    private T _0;
    public readonly int Length => 56;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(57)] public struct Array57<T>
{
    private T _0;
    public readonly int Length => 57;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(58)] public struct Array58<T>
{
    private T _0;
    public readonly int Length => 58;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(59)] public struct Array59<T>
{
    private T _0;
    public readonly int Length => 59;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(60)] public struct Array60<T>
{
    private T _0;
    public readonly int Length => 60;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(61)] public struct Array61<T>
{
    private T _0;
    public readonly int Length => 61;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(62)] public struct Array62<T>
{
    private T _0;
    public readonly int Length => 62;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(63)] public struct Array63<T>
{
    private T _0;
    public readonly int Length => 63;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(64)] public struct Array64<T>
{
    private T _0;
    public readonly int Length => 64;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(65)] public struct Array65<T>
{
    private T _0;
    public readonly int Length => 65;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(68)] public struct Array68<T>
{
    private T _0;
    public readonly int Length => 68;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(73)] public struct Array73<T>
{
    private T _0;
    public readonly int Length => 73;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(80)] public struct Array80<T>
{
    private T _0;
    public readonly int Length => 80;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(96)] public struct Array96<T>
{
    private T _0;
    public readonly int Length => 96;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(100)] public struct Array100<T>
{
    private T _0;
    public readonly int Length => 100;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(104)] public struct Array104<T>
{
    private T _0;
    public readonly int Length => 104;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(112)] public struct Array112<T>
{
    private T _0;
    public readonly int Length => 112;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(120)] public struct Array120<T>
{
    private T _0;
    public readonly int Length => 120;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(127)] public struct Array127<T>
{
    private T _0;
    public readonly int Length => 127;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(128)] public struct Array128<T>
{
    private T _0;
    public readonly int Length => 128;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(140)] public struct Array140<T>
{
    private T _0;
    public readonly int Length => 140;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(144)] public struct Array144<T>
{
    private T _0;
    public readonly int Length => 144;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(192)] public struct Array192<T>
{
    private T _0;
    public readonly int Length => 192;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(256)] public struct Array256<T>
{
    private T _0;
    public readonly int Length => 256;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(356)] public struct Array356<T>
{
    private T _0;
    public readonly int Length => 356;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(384)] public struct Array384<T>
{
    private T _0;
    public readonly int Length => 384;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(400)] public struct Array400<T>
{
    private T _0;
    public readonly int Length => 400;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(436)] public struct Array436<T>
{
    private T _0;
    public readonly int Length => 436;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(452)] public struct Array452<T>
{
    private T _0;
    public readonly int Length => 452;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(464)] public struct Array464<T>
{
    private T _0;
    public readonly int Length => 464;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(512)] public struct Array512<T>
{
    private T _0;
    public readonly int Length => 512;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(640)] public struct Array640<T>
{
    private T _0;
    public readonly int Length => 640;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(768)] public struct Array768<T>
{
    private T _0;
    public readonly int Length => 768;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(769)] public struct Array769<T>
{
    private T _0;
    public readonly int Length => 769;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(1024)] public struct Array1024<T>
{
    private T _0;
    public readonly int Length => 1024;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(3000)] public struct Array3000<T>
{
    private T _0;
    public readonly int Length => 3000;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(3438)] public struct Array3438<T>
{
    private T _0;
    public readonly int Length => 3438;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(5366)] public struct Array5366<T>
{
    private T _0;
    public readonly int Length => 5366;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(8000)] public struct Array8000<T>
{
    private T _0;
    public readonly int Length => 8000;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(8192)] public struct Array8192<T>
{
    private T _0;
    public readonly int Length => 8192;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

[InlineArray(16384)] public struct Array16384<T>
{
    private T _0;
    public readonly int Length => 16384;

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public Span<T> AsSpan() => SpanHelpers.CreateSpan(ref _0, Length);

    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly ReadOnlySpan<T> AsReadOnlySpan() => SpanHelpers.CreateReadOnlySpan(in _0, Length);


    public void CopyTo(Span<T> destination) => AsReadOnlySpan().CopyTo(destination);


    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan) => AsReadOnlySpan().Overlaps(otherSpan);

    [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Overlaps(ReadOnlySpan<T> otherSpan, out int elementOffset) => AsReadOnlySpan().Overlaps(otherSpan, out elementOffset);


    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start) => AsReadOnlySpan().Slice(start);

    #pragma warning disable CS9182 // Inline array 'Slice' method will not be used for element access expression.
    [UnscopedRef, MethodImpl(MethodImplOptions.AggressiveInlining)] public ReadOnlySpan<T> Slice(int start, int length) => AsReadOnlySpan().Slice(start, length);
    #pragma warning restore CS9182 // Inline array 'Slice' method will not be used for element access expression.
}

