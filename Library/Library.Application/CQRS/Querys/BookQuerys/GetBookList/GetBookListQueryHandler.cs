using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBookList
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, BookListVm>
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
            //TODO: понять как не преобразовывать каждый раз в список
            var bookQuery = await _webDbContext.Books.Include(x => x.Author)/*.Include(x => x.Genres)*/
                 .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);
            if (request.AuthorId != null)
            {
                bookQuery = bookQuery.Where(b => b.Author.Id == request.AuthorId).ToList();
            }
            //if (!String.IsNullOrWhiteSpace(request.BookGenre))
            //{
            //    bookQuery = bookQuery.Where(b => b.Genre.FirstName == request.BookGenre).ToList();
            //}
            if (!String.IsNullOrWhiteSpace(request.BookName))
            {
                bookQuery = bookQuery.Where(b => b.Title == request.BookName).ToList();
            }
            return new BookListVm { Books = bookQuery };
        }
    }
}
