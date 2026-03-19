namespace Blocks.Exceptions;

public class NotFoundException : HttpException
{
    public NotFoundException(string message) : base(System.Net.HttpStatusCode.NotFound, message)
    {
    }

    public NotFoundException(string? message, Exception ex) : base(System.Net.HttpStatusCode.NotFound, message, ex)
    {
    }
    
}