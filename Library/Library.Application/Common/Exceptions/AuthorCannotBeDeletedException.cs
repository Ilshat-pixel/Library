using System;

namespace Library.Application.Common.Exceptions
{
    public class AuthorCannotBeDeletedException : Exception
    {
        public AuthorCannotBeDeletedException(string name, object key) : base($"Entity \"{name}\" ({key}) can`t be deleted because has books.")
        {
        }
    }
}
