using AutoMapper;
using Library.API.Models.LibraryCard;
using Library.Application.CQRS.Commands.LibraryCardCommands.CreateCommand;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class LibraryCardController : BaseController
    {
        private readonly IMapper _mapper;

        public LibraryCardController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Добавляет новую картолчку
        /// </summary>
        /// <param name="libraryCardDto">Модель для созадния карточки</param>
        /// <returns>ID  карточки</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] LibraryCardDto libraryCardDto)
        {
            var command = _mapper.Map<CreateLibraryCardCommand>(libraryCardDto);
            var humanId = await Mediator.Send(command);
            return Ok(humanId);
        }
    }
}
