using FluentValidation;

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class GetHumanListQueryValidator : AbstractValidator<GetHumanListQuery>
    {
        public GetHumanListQueryValidator()
        {
        }
    }
}
