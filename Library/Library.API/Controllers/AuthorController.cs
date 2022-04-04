using AutoMapper;
using Library.API.DTOs.Author;
using Library.Application.CQRS.Commands.AuthorCommands.CreateAuthorCommand;
using Library.Application.CQRS.Commands.AuthorCommands.DeleteAuthor;
using Library.Application.CQRS.Querys.AuhtorsQuerys.GetAuthorList;
using Library.Application.CQRS.Querys.BookQuerys.GetBookList;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    public class AuthorController:BaseController
    {
        private readonly IMapper _mapper;

        public AuthorController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<AuthorListVm>> GetAll()
        {
            var query = new GetAuthorListQuery
            {
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);

        }

        [HttpGet]
        public async Task<ActionResult<BookListVm>> GetAuthorBooks( int id)
        {
            var query = new GetBookListQuery
            {
                AuthorId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAuthorDto createBookDto)
        {
            var command = _mapper.Map<CreateAuthorCommand>(createBookDto);
            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }
    }
}
