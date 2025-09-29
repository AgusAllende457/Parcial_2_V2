using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class AutomovilValidator : AbstractValidator<Automovil>
    {
        public AutomovilValidator()
        {
            RuleFor(a => a.Marca).NotEmpty();
            RuleFor(a => a.Modelo).NotEmpty();
            RuleFor(a => a.Color).NotEmpty();
        }

    }
}