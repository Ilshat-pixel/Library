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
        private readonly IMemoryCache _memoryCache;
        public HumanController(IMapper mapper, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        [HttpGet("{isAuthor}/{searchString}")]
        public async Task<ActionResult<HumanListVm>> GetAll(bool? isAuthor, string searchString)
        {
            //TODO: Разобраться как правильно подбирать ключи
            // TODO: понять почему в ретурне могу вызвать cacheValue
            var key = "AllHumans";
            if (!_memoryCache.TryGetValue(key, out HumanListVm cacheValue))
            {
                var query = new GetHumanListQuery { };
                var vm = await Mediator.Send(query);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                       .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                _memoryCache.Set(key, vm, cacheEntryOptions);
            }
            var humans = cacheValue.Humans;
            if(isAuthor == true)
            {
             humans = humans.Where(h => h.Books.Count() > 0).ToList();
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                humans = humans.Where(h=>(h.Name.ToLower()+h.Surname.ToLower()+h.Patronymic.ToLower()).Contains(searchString.ToLower())).ToList();
            }
        
            return Ok(humans);

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
