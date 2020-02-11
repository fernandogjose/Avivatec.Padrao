using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Avivatec.Padrao.Application.Cqrs.Usuarios.Queries.ObterUsuario
{
    public class ObterUsuarioQueryHandler : IRequestHandler<ObterUsuarioQuery, ObterUsuarioResponse>
    {
        public Task<ObterUsuarioResponse> Handle(ObterUsuarioQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
