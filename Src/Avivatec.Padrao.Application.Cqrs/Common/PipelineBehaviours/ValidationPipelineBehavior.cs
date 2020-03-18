using Avivatec.Padrao.Application.Cqrs.Usuarios.Commands.AdicionarUsuario;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Avivatec.Padrao.Application.Cqrs.Common.PipelineBehaviours
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : BaseResponse
    {
        private readonly IEnumerable<IValidator<TRequest>> _validadores;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validadores)
        {
            _validadores = validadores;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);

            var erros = _validadores
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .Select(errors => errors.ErrorMessage)
                .ToList();

            if (erros.Any())
                return Task.FromResult(new BaseResponse(Guid.NewGuid(), System.Net.HttpStatusCode.BadRequest, erros) as TResponse);


            return next();
        }
    }
}
