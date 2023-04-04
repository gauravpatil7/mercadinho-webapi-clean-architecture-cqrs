namespace MercadinhoWeb.Infra.Data.Exceptions;

public class ResourceUpdateException : Exception
{
    public ResourceUpdateException(string message, Exception ex) : base(message, ex) { }
}
