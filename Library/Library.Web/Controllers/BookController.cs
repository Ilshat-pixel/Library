using AutoMapper;
using Library.Web.DTOs.Book;
using Library.Application.CQRS.Commands.BookCommands.CreateBook;
using Library.Application.CQRS.Commands.BookCommands.DeleteBook;
using Library.Application.CQRS.Querys.BookQuerys.GetBookList;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Library.Web.Controllers;
using Library.Application.CQRS.Querys.AuhtorsQuerys.GetAuthorList;
using Library.Application.CQRS.Querys.GenreQuerys.GetGenreListQuery;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.API.Controllers
{
    [Route("[controller]/[action]")]
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;

        public BookController(IMapper mapper)
        {
            _mapper = mapper;
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
        public async Task<ActionResult<BookListVm>> Index([FromQuery] int? authorId = null, [FromQuery] string bookName = null, [FromQuery] string bookGenre = null)
        
        {

            var query = new GetBookListQuery
            {
                AuthorId = authorId,
                BookGenre = bookGenre,
                BookName = bookName,
                CacheKey = $"{authorId}/{bookGenre}/{bookName}"
            };
            var vm = await Mediator.Send(query);

            return View(vm);

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
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<CreateBookDto>> Create()
        {
            var authorListQuery = new GetAuthorListQuery();
            var authorsList = await Mediator.Send(authorListQuery);
            var genreListQuery = new GetGenreListQuery();
            var groupList = await Mediator.Send(genreListQuery);
            ViewBag.Authors = authorsList.Authors.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Genres = groupList.Genres.Select(x => new SelectListItem { Text = x.GenreName, Value = x.Id.ToString() }).ToList();
            return View();
        }


        /// <summary>
        /// Создает новую книгу
        /// </summary>
        /// <param name="createBookDto">Dto для создания книги</param>
        /// <returns>Возращает Id книги</returns>
        [HttpPost]
        public async Task<ActionResult> Create( CreateBookDto createBookDto)
        {
            var command = _mapper.Map<CreateBookCommand>(createBookDto);
            var bookId = await Mediator.Send(command);
            return RedirectToAction("Index");
        }

    }
}
