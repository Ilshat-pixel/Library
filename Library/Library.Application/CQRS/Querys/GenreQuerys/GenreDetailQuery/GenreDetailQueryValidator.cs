using FluentValidation;

namespace Library.Application.CQRS.Querys.GenreQuerys.GenreDetailQuery
{
    public class GenreDetailQueryValidator : AbstractValidator<GenreDetailQuery>
    {
        public GenreDetailQueryValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
