using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Commands.AuthorCommands.CreateAuthorCommand
{
    //public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, IList<int>>
    //{

    //    private readonly IWebDbContext _dbContext;

    //    public CreateAuthorCommandHandler(IWebDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public Task<IList<int>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    //    {
    //        var author = new Author
    //        {
    //            FirstName = request.FirstName,
    //            LastName = request.LastName,
    //            MiddleName = request.MiddleName
    //        };
    //        var books = request.Books.Select(new Book {
            
    //        })
            
    //    }
    //}
}
