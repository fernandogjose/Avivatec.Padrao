using Avivatec.Padrao.Application.Cqrs.Common;
using MediatR;
using Newtonsoft.Json;

namespace Avivatec.Padrao.Application.Cqrs.Usuarios.Commands.AdicionarUsuario
{
    public class AdicionarUsuarioCommand : IRequest<BaseResponse>
    {
        [JsonConstructor]
        public AdicionarUsuarioCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; }

        public string Senha { get; }
    }
}
