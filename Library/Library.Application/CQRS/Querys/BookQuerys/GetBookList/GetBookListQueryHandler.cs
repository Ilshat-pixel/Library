using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBookList
{
    public class GetBookListQueryHandler:IRequestHandler<GetBookListQuery,BookListVm>
    {
        private readonly IWebDbContext _webDbContext;
        private readonly IMapper _mapper;

        public GetBookListQueryHandler(IWebDbContext webDbContext, IMapper mapper)
        {
            _webDbContext = webDbContext;
            _mapper = mapper;
        }

       
        public async Task<BookListVm> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var bookQuery = await _webDbContext.Books
                 .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

            return new BookListVm{ Books = bookQuery };
        }
    }
}
