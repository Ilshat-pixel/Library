using AutoMapper;
using Library.Application.CQRS.Commands.PersonCommands.CreatePerson;
using Library.Application.CQRS.Commands.PersonCommands.DeletePerson;
using Library.Application.CQRS.Commands.PersonCommands.DeletePersonByFullName;
using Library.Application.CQRS.Commands.PersonCommands.UpdatePerson;
using Library.Application.CQRS.Querys.HumanQuerys.GetHumanList;
using Library.Web.Controllers;
using Library.Web.DTOs.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class PersonController : BaseController
    {
        private readonly IMapper _mapper;
        public PersonController(IMapper mapper)
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
        /// <param name="isAuthor">Проверяет является ли  человек автором</param>
        /// <param name="searchString">Выполняет поиск в имени, фамилии и отчестве</param>
        /// <returns>Возращает список людей</returns>
        /// <response code="200">Успешно</response>
        /// <response code="401">Если ключ в headers оказался не верен</response>   
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<HumanListVm>> GetAll([FromQuery] bool? isAuthor, string searchString)
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
        /// <summary>
        /// Удаляет человека из Бд
        /// </summary>
        /// <remarks>
        /// Пример запроса
        /// Get /5
        /// </remarks>
        /// <param name="id">Id человека для удаления</param>
        /// <returns>yНичего не возрашает</returns>
        /// <response code="401">Если ключ в headers оказался не верен</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePersonCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeletePersonByFullName([FromQuery] string FirstName, string MiddleName, string LastName)
        {

            var command = new DeletePersonByFullNameCommand
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName
            };
            await Mediator.Send(command);
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateNoteDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdatePersonDto updateNoteDto)
        {
            var command = _mapper.Map<UpdatePersonCommand>(updateNoteDto);
            var personVm = await Mediator.Send(command);
            return Ok(personVm);
        }
        /// <summary>
        /// Создает нового человека
        /// </summary>
        /// <param name="createpersonDto">Dto для создания человека</param>
        /// <returns>Созданного человека</returns>
        /// <response code="200">Успешно</response>
        /// <response code="401">Если ключ в headers оказался не верен</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PersonVm>> Create([FromBody] CreatePersonDto createHumanDto)
        {
            var command = _mapper.Map<CreatePersonCommand>(createHumanDto);
            var personVm = await Mediator.Send(command);
            return Ok(personVm);
        }

    }
}
