using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Common.Exceptions
{
    public class BookCannotBeDeletedException : Exception
    {
        public BookCannotBeDeletedException(string name, object key) : base($"Книга \"{name}\" ({key}) не может быть удалена т.к  выдана пользователю.")
        {
        }
    }
}
