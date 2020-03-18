using FluentValidation;

namespace Avivatec.Padrao.Application.Cqrs.Usuarios.Commands.AdicionarUsuario
{
    public class AdicionarUsuarioCommandValidator : AbstractValidator<AdicionarUsuarioCommand>
    {
        public AdicionarUsuarioCommandValidator()
        {
            RuleFor(usr => usr.Email)
                   .NotEmpty()
                   .WithMessage("Um email deve ser informado")
                   .EmailAddress()
                   .WithMessage("Insira um e-mail válido");

            RuleFor(usr => usr.Senha)
                   .NotEmpty()
                   .WithMessage("Uma senha deve ser informada")
                   .MinimumLength(8)
                   .WithMessage("A senha deve ter mais de 8 caracteres");

        }
    }
}
