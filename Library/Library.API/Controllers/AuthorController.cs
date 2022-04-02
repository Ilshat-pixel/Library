using AutoMapper;
using Library.API.DTOs.Author;
using Library.Application.CQRS.Commands.AuthorCommands.CreateAuthorCommand;
using Library.Application.CQRS.Commands.AuthorCommands.DeleteAuthor;
using Library.Application.CQRS.Querys.BookQuerys.GetBookList;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    public class AuthorController:BaseController
    {
        private readonly IMapper _mapper;

        public AuthorController(IMapper mapper)
        {
            _mapper = mapper;
        }


        //[HttpGet]
        //public async Task<ActionResult<AuthorsListVm>> GetAll()
        //{
        //    var query = new GetAuthorsListQuery
        //    {
        //    };
        //    var vm = await Mediator.Send(query);

        //    return Ok(vm);

        //}
        //[HttpGet]
        //public async Task<ActionResult<AuthorBooksVm>> GetAuthorBooks([FromQuery]int id)
        //{
        //    var query = new GetAuthorBooksQuery
        //    {
        //    };
        //    var vm = await Mediator.Send(query);

        //    return Ok(vm);
        //}


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAuthorDto createAuthorDto)
        {
            var command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);
            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }
    }
}
