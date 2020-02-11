using Avivatec.Padrao.Application.Cqrs.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Avivatec.Padrao.Application.Cqrs.Usuarios.Commands.AdicionarUsuario
{
    public class AdicionarUsuarioCommandHandler : IRequestHandler<AdicionarUsuarioCommand, BaseResponse>
    {
        public Task<BaseResponse> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new BaseResponse(Guid.NewGuid(), System.Net.HttpStatusCode.OK, null, new { id = 1}));
        }
    }
}
