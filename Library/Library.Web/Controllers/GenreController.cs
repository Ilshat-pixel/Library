using AutoMapper;
using Library.Web.DTOs.Genre;
using Library.Application.CQRS.Commands.GenreCommands.CreateGenre;
using Library.Application.CQRS.Querys.GenreQuerys.GetGenreListQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Library.Web.Controllers;
using Library.Application.CQRS.Commands.GenreCommands.DeleteGenre;
using Library.Application.CQRS.Querys.GenreQuerys.GenreDetailQuery;
using Library.Application.CQRS.Commands.GenreCommands.UpdateGenre;

namespace Library.API.Controllers
{
    [Produces("application/json")]
    [Route("web/[controller]/[action]")]
    public class GenreController : BaseController
    {
        private readonly IMapper _mapper;

        public GenreController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetGenreListQuery();
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
            var query = new GenreDetailQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            var dto = new UpdateGenreDto { Id = vm.Id,Name=vm.GenreName };
            return View(dto);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create(CreateGenreDto createGenreDto)
        {
            var command = _mapper.Map<CreateGenreCommand>(createGenreDto);
            var Id = await Mediator.Send(command);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateGenreDto dto)
        {
            var command = _mapper.Map<UpdateGenreCommand>(dto);
            await Mediator.Send(command);
            return RedirectToAction("Index");
        }
      
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteGenreCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
