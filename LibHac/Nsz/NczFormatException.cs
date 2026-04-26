using System;

namespace LibHac.NSZ;

public class NczFormatException(string message = null, Exception ex = null) : Exception(message, ex)
{
}