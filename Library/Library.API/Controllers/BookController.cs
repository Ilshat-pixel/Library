using AutoMapper;
using Library.Application.CQRS.Querys.BookQuerys.GetBookList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using System;
using System.Linq;
using Library.Application.CQRS.Commands.BookCommands.DeleteBook;
using Library.API.Controllers.Models.Book;
using Library.Application.CQRS.Commands.BookCommands.CreateBook;

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="bookName"></param>
        /// <param name="bookGenre"></param>
        /// <returns></returns>
        [HttpGet("{authorId}/{bookName}/{bookGenre}")]
        public async Task<ActionResult<BookListVm>> GetAll(int? authorId, string bookName, string bookGenre)
        {
         
                var query = new GetBookListQuery(authorId) {};
                var vm = await Mediator.Send(query);

            
          

            return Ok(vm);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var command = new DeleteBookCommand
            {
                Id = id
            };
            await Mediator.Send(command);       
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateBookDto createBookDto)
        {
            var command = _mapper.Map<CreateBookCommand>(createBookDto);
            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

    }
}
