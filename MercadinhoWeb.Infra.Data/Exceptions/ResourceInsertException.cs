using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Infra.Data.Exceptions;
public class ResourceInsertException : Exception
{
    public ResourceInsertException(string message, Exception ex) : base(message, ex) { }
}
