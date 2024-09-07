namespace MercadinhoWeb.Infra.Data.Exceptions;

public class ResourceDeleteException : Exception
{
    public ResourceDeleteException(string message, Exception ex) : base(message, ex)
    {
    }
}