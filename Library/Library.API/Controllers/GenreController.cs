using AutoMapper;
using Library.API.DTOs.Genre;
using Library.Application.CQRS.Commands.GenreCommands.CreateGenre;
using Library.Application.CQRS.Querys.GenreQuerys.GetGenreListQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class GenreController : BaseController
    {
        private readonly IMapper _mapper;

        public GenreController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create([FromBody] CreateGenreDto createGenreDto)
        {
            var command = _mapper.Map<CreateGenreCommand>(createGenreDto);
            var Id = await Mediator.Send(command);
            return Ok(Id);
        }
        [HttpGet]
        public async Task<ActionResult<GenreListVm>> GetAll()
        {
            var query = new GetGenreListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        //[HttpGet]
        //public Task<ActionResult<BooksCountByGenreVm>> GetBooksCountByGenre()
        //{

        //}
    }
}
