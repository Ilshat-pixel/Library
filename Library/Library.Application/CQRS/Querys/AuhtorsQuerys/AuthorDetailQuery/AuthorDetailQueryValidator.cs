using FluentValidation;

namespace Library.Application.CQRS.Querys.AuhtorsQuerys.AuthorDetailQuery
{
    public class AuthorDetailQueryValidator : AbstractValidator<AuthorDetailQuery>
    {
        public AuthorDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
