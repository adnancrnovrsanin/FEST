using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ModelDTOs;
using FluentValidation;

namespace Application.Theatres
{
    public class TheatreValidator : AbstractValidator<TheatreDto>
    {
        public TheatreValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.YearOfCreation).NotEmpty();
        }
    }
}