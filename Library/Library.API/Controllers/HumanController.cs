using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
      //  [HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> Delete (int Id)
        //{
        //}

    }
}
