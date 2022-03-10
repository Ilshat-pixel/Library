using AutoMapper;
using Library.API.Controllers.Models.Human;
using Library.Application.CQRS.Commands.HumanCommands.CreateHuman;
using Library.Application.CQRS.Commands.HumanCommands.DeleteHuman;
using Library.Application.CQRS.Querys.HumanQuerys.GetHumanList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class HumanController:BaseController
    {
        private readonly IMapper _mapper;
        public HumanController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Возращает список людей
        /// </summary>
        /// <remarks>
        /// Пример запроса
        /// Get /true/Alexey
        /// </remarks>
        /// <param name="isAuthor">Выводит людей, которые являются авторами</param>
        /// <param name="searchString">Выполняет поиск в имени, фамилии и отчестве</param>
        /// <returns>Возращает список людей</returns>
        /// <response code="200">Успешно</response>
        /// <response code="401">Если ключ в headers оказался не верен</response>   
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createHumanDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateHumanDto createHumanDto)
        {
            var command = _mapper.Map<CreateHumanCommand>(createHumanDto);
            var humanId = await Mediator.Send(command);
            return Ok(humanId);
        }

    }
}
