using Avivatec.Padrao.Application.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace Avivatec.Padrao.Api.Middlewares
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var response = new { erros = new List<ErroViewModel>(0) };
                    if (contextFeature != null)
                    {
                        response.erros.Add(new ErroViewModel(500, "Erro inesperado no servidor - " + contextFeature.Error.Message));
                    }
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                });
            });
        }
    }
}
