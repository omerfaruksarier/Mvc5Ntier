using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(x => x.CountryName).NotEmpty().WithMessage("Ülke adı boş olamaz.");
            RuleFor(x => x.CountryName).MinimumLength(4).WithMessage("Ülke adı en az 4 karakter olmalıdır.");
            RuleFor(x => x.CountryName).MaximumLength(50).WithMessage("Ülke adı en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.CountryCurrency).NotEmpty().WithMessage("Para birimi boş olamaz.");
            RuleFor(x => x.Capital).NotEmpty().WithMessage("Başkent boş olamaz.");
        }
    }
}
