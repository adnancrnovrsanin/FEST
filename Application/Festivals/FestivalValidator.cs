using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ModelDTOs;
using FluentValidation;

namespace Application.Festivals
{
    public class FestivalValidator : AbstractValidator<FestivalDto>
    {
        public FestivalValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.ZipCode).NotEmpty();
        }
    }
}