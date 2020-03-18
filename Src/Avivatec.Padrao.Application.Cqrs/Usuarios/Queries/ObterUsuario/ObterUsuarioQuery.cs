using MediatR;
using Newtonsoft.Json;

namespace Avivatec.Padrao.Application.Cqrs.Usuarios.Queries.ObterUsuario
{
    public class ObterUsuarioQuery : IRequest<ObterUsuarioResponse>
    {
        public int IdUsuario { get; }


        [JsonConstructor]
        public ObterUsuarioQuery(int idUsuario)
        {
            this.IdUsuario = idUsuario;
        }
    }
}
