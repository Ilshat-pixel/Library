using System.Threading.Tasks;
using AutoMapper;
using Library.Application.CQRS.Commands.AuthorCommands.CreateAuthorCommand;
using Library.Application.CQRS.Commands.AuthorCommands.DeleteAuthor;
using Library.Application.CQRS.Commands.AuthorCommands.UpdateAuthorCommand;
using Library.Application.CQRS.Querys.AuhtorsQuerys.AuthorDetailQuery;
using Library.Application.CQRS.Querys.AuhtorsQuerys.GetAuthorList;
using Library.Application.CQRS.Querys.BookQuerys.GetBookList;
using Library.Web.DTOs.Author;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly IMapper _mapper;

        public AuthorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetAuthorListQuery();
            var vm = await Mediator.Send(query);
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var query = new AuthorDetailQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            var dto = new UpdateAuthorDto { Id = vm.Id, FirstName = vm.FirstName, LastName = vm.LastName, MiddleName = vm.MiddleName };
            return View(dto);
        }

        [HttpGet]
        public async Task<ActionResult<BookListVm>> GetAuthorBooks(int id)
        {
            var query = new GetBookListQuery
            {
                AuthorId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDto createAuthorDto)
        {
            var command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);
            var bookId = await Mediator.Send(command);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAuthorDto dto)
        {
            var command = _mapper.Map<UpdateAuthorCommand>(dto);
            await Mediator.Send(command);
            return RedirectToAction("Index");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return RedirectToAction("Index");
        }


    }
}
