using FluentValidation;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBookList
{
    public class GetBookListQueryValidator : AbstractValidator<GetBookListQuery>
    {
        public GetBookListQueryValidator() { }
    }
}
