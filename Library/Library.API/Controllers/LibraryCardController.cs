using AutoMapper;
using Library.API.Models.LibraryCard;
using Library.Application.CQRS.Commands.LibraryCardCommands.CreateCommand;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class LibraryCardController:BaseController
    {
        private readonly IMapper _mapper;

        public LibraryCardController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] LibraryCardDto libraryCardDto)
        {
            var command = _mapper.Map<CreateLibraryCardCommand>(libraryCardDto);
            var humanId = await Mediator.Send(command);
            return Ok(humanId);
        }
    }
}
