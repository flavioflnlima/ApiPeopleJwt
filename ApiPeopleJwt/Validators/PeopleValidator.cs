using People = ApiPeopleJwt.Models.PeopleViewModel;
using FluentValidation;
namespace ApiPeopleJwt.Validators
{
    public class PeopleValidator : AbstractValidator<People>
    {
        public PeopleValidator()
        {
            RuleFor(c => c.Email)
                .Matches(
                    "^(([^<>()[\\]\\.,;:\\s@\"]+(\\.[^<>()[\\]\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$")
                .WithMessage("Email invalido");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Dados obrigatórios não informados.")
                .MaximumLength(100).WithMessage("Número máximo de 100 caracteres");

            RuleFor(c => c.Document)
                .NotEmpty().WithMessage("Dados obrigatórios não informados.")
                .MaximumLength(11).WithMessage("A quantidade máxima de caracteres exedida")
                .MinimumLength(11).WithMessage("Quantidade menor que o exigido");
        }
    }
}
