using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class GetHumanListQueryValidator : AbstractValidator<GetHumanListQuery>
    {
        public GetHumanListQueryValidator()
        {
        }
    }
}
