namespace NSW.Core.Exceptions;

public class UnpackMetadataNotFoundException(string message) : System.IO.FileNotFoundException(message)
{
}