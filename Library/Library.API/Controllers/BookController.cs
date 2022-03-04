using AutoMapper;
using Library.Application.CQRS.Querys.BookQuerys.GetBookList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Library.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BookController:BaseController
    {
        private readonly IMapper _mapper;
        //TODO: Разобраться как правильно организовать сервис кэширования
        private readonly IMemoryCache _memoryCache;
        public BookController(IMapper mapper, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        [HttpGet("{authorId}")]
        public async Task<ActionResult<BookListVm>> GetAll(int? authorId)
        {
            //TODO: Разобраться как правильно подбирать ключи
            // TODO: понять почему в ретурне могу вызвать cacheValue
            var key = "AllBooks";
            if (!_memoryCache.TryGetValue(key, out BookListVm cacheValue))
            {
                var query = new GetBookListQuery { };
                var vm = await Mediator.Send(query);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                       .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                _memoryCache.Set(key, vm, cacheEntryOptions);
            }
            if (authorId != null)
            {
                return Ok(cacheValue.Books.Where(x => x.Author.Id == authorId).FirstOrDefault());
            }

            return Ok(cacheValue);

        }
    }
}
