using System;
using System.Net;

namespace Library.API.Exceprions
{
    public class HttpStatusException : Exception
    {
        public HttpStatusException(HttpStatusCode code, string message) : base($"Status code:{code}. Exceptions:{message}")
        {
        }
    }
}
