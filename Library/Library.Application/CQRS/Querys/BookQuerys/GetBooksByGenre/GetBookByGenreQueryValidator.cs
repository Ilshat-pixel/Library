using FluentValidation;

namespace Library.Application.CQRS.Querys.BookQuerys.GetBooksByGenre
{
    public class GetBookByGenreQueryValidator : AbstractValidator<GetBookByGenreQuery>
    {
        public GetBookByGenreQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
