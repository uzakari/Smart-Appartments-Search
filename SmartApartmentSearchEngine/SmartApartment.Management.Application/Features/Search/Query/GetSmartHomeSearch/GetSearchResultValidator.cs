using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch
{
    public class GetSearchResultValidator: AbstractValidator<GetSearchQuery>
    {

        public GetSearchResultValidator()
        {
            RuleFor(p => p.searchQuery)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.scope)
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
