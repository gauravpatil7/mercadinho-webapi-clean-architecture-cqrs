namespace MercadinhoWeb.Infra.Data.Exceptions;
public class ResourceInsertException : Exception
{
    public ResourceInsertException(string message, Exception ex) : base(message, ex) { }
}
