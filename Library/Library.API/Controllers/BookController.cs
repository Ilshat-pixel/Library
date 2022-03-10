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
    [ApiController]
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
        /// Возрашает список книг, а так же выполняет фильтрацию
        /// </summary>
        /// <remarks>
        /// GEt
        /// /5/Тутназваниекниги/Тутжанркниги
        /// </remarks>
        /// <param name="authorId">Параметр который, используется для поиска по автору</param>
        /// <param name="bookName">Параметр который, используется для поиска по название книги </param>
        /// <param name="bookGenre">Параметр который, используется для поиска по жанру книги</param>
        /// <returns>Возращает список книг</returns>
        /// <response code="200">Успешно</response>
        /// <response code="401">Если ключ в headers оказался не верен</response> 
        [HttpGet]
        public async Task<ActionResult<BookListVm>> GetAll([FromQuery]int? authorId=null, string bookName=null, string bookGenre=null)
        {
         
                var query = new GetBookListQuery {
                AuthorId =authorId,
                BookGenre = bookGenre,
                BookName = bookName,
                CacheKey = $"{authorId}/{bookGenre}/{bookName}"
                };
                var vm = await Mediator.Send(query);

                return Ok(vm);

        }
        /// <summary>
        /// Удаляет книгу из Бд
        /// </summary>
        /// <remarks>
        /// Пример запроса
        /// Get /5
        /// </remarks>
        /// <param name="id">Id книги для удаления</param>
        /// <returns>yНичего не возрашает</returns>
        /// <response code="401">Если ключ в headers оказался не верен</response>
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
        /// <summary>
        /// Создает новую книгу
        /// </summary>
        /// <param name="createBookDto">Dto для создания книги</param>
        /// <returns>Возращает Id книги</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateBookDto createBookDto)
        {
            var command = _mapper.Map<CreateBookCommand>(createBookDto);
            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

    }
}
