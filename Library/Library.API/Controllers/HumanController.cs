using AutoMapper;
using Library.API.Controllers.Models.Human;
using Library.Application.CQRS.Commands.HumanCommands.CreateHuman;
using Library.Application.CQRS.Commands.HumanCommands.DeleteHuman;
using Library.Application.CQRS.Querys.HumanQuerys.GetHumanList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class HumanController:BaseController
    {
        private readonly IMapper _mapper;
        public HumanController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<HumanListVm>> GetAll([FromQuery]bool? isAuthor, string searchString)
        {
                var query = new GetHumanListQuery
                {
                IsAuthor = isAuthor,
                SearchString = searchString,
                CacheKey = $"{isAuthor}/{searchString}"
                };
                var vm = await Mediator.Send(query);

        
            return Ok(vm);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteHumanCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateHumanDto createHumanDto)
        {
            var command = _mapper.Map<CreateHumanCommand>(createHumanDto);
            var humanId = await Mediator.Send(command);
            return Ok(humanId);
        }

    }
}
