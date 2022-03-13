using AutoMapper;
using Library.API.DTOs.Genre;
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
        public Task<ActionResult<GenreVm>> Create([FromBody] CreateGenreDto createGenreDto)
        {

        }
        [HttpGet]
        public Task<ActionResult<GenreListVm>> GetAll()
        {

        }
        [HttpGet]
        public Task<ActionResult<BooksCountByGenreVm>> GetBooksCountByGenre()
        {

        }
    }
}
