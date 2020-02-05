using Avivatec.Padrao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Avivatec.Padrao.Api.Middlewares
{
    public class SegurancaMiddleware
    {
        private readonly RequestDelegate _next;

        public SegurancaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUsuarioService usuarioService)
        {
            // Exceções para a validação
            if (context.Request.Path.Value.Contains("/swagger") ||
                context.Request.Path.Value.Contains("/login") ||
                context.Request.Path.Value.Contains("/editar-senha") ||
                context.Request.Path.Value.Contains("/cadastrar-senha"))
            {
                await _next.Invoke(context);
                return;
            }

            // Verifica se tem o token
            //if (!context.Request.Headers.TryGetValue("authorization", out StringValues token))
            //{
            //    throw new UnauthorizedAccessException("Token inválido");
            //}

            //// Verifica se tem o id do usuário
            //if (!context.Request.Headers.TryGetValue("usuarioId", out StringValues usuarioId))
            //{
            //    throw new UnauthorizedAccessException("Usuário não encontrado");
            //}

            // Verifica se o usuário logado é o mesmo do token
            //if (SenhaHelper.CriarHash(context.User.Identity.Name) != usuarioId[0])
            //{
            //    throw new UnauthorizedAccessException("Usuário não encontrado");
            //}

            await _next.Invoke(context);
        }
    }

    public static class SegurancaExtension
    {
        public static IApplicationBuilder SegurancaValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<SegurancaMiddleware>();
            return app;
        }
    }
}