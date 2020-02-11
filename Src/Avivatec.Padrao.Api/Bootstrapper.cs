using Avivatec.Padrao.Application.Cqrs.Common.PipelineBehaviours;
using Avivatec.Padrao.Application.Cqrs.Usuarios.Commands.AdicionarUsuario;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Avivatec.Padrao.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection Bootstrap(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            services.AddMediatR(typeof(AdicionarUsuarioCommand).GetTypeInfo().Assembly);

            return services;
        }
    }
}
