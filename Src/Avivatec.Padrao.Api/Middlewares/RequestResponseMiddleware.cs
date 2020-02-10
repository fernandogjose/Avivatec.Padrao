using Avivatec.Padrao.Application.ViewModels;
using Avivatec.Padrao.Helpers.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Avivatec.Padrao.Api.Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtHelper _jwtHelper;

        public RequestResponseMiddleware(RequestDelegate next, JwtHelper jwtHelper)
        {
            _next = next;
            _jwtHelper = jwtHelper;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var method = context.Request.Method;
                var request = context.Request;

                // Se for diferente do verbo OBTIONS E GET, recupera o id do usuario logado
                if (method.ToUpper() != "OPTIONS" && method.ToUpper() != "GET")
                {
                    var stream = request.Body;
                    var originalContent = new StreamReader(stream).ReadToEnd();
                    var notModified = true;

                    var dataSource = originalContent;
                    if (dataSource.Contains("{") && dataSource.Contains("}"))
                    {
                        var idUsuario = RecuperaIdUsuario(request);
                        if (idUsuario > 0)
                        {
                            if (dataSource == "{}")
                            {
                                dataSource = dataSource.Replace("}", "\"IdUsuarioCadastro\":" + idUsuario + ",\"IdUsuarioAlteracao\":" + idUsuario + "}");
                            }
                            else
                            {
                                dataSource = dataSource.Replace("}", ",\"IdUsuarioCadastro\":" + idUsuario + ",\"IdUsuarioAlteracao\":" + idUsuario + "}");
                            }  
                            
                            var requestContent = new StringContent(dataSource, Encoding.UTF8, "application/json");
                            stream = await requestContent.ReadAsStreamAsync();
                            notModified = false;
                        }
                    }

                    if (notModified)
                    {
                        var requestData = Encoding.UTF8.GetBytes(originalContent);
                        stream = new MemoryStream(requestData);
                    }

                    request.Body = stream;
                }

                var originalBodyStream = context.Response.Body;

                using (var responseBody = new MemoryStream())
                {

                    context.Response.Body = responseBody;
                    await _next(context);

                    // Verifica o status code do response
                    context.Response.StatusCode = await ObterStatusCode(context.Response);

                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private async Task<int> ObterStatusCode(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            Encoding utf8 = new UTF8Encoding(false);

            //TODO: Texto vindo ByteOrderMark, não consegui remover com Encoding, uma alternativa rapido foi via regex, verificar outras alternativas
            string text = await new StreamReader(response.Body, utf8).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            // Verificar se teve algum erro de negócio e voltar StatusCode diferente de 200 para o angular
            IList<ErroViewModel> list = new List<ErroViewModel>();

            var responseErros = new { Erros = list };
            if (text.ToLower().Contains("erros"))
            {
                var responseObject = JsonConvert.DeserializeAnonymousType(text, responseErros);
                if (responseObject != null && responseObject.Erros != null && responseObject.Erros.Any())
                {
                    response.StatusCode = responseObject.Erros.First(x => x.Codigo > 0).Codigo;
                }
            }

            return response.StatusCode;
        }

        public int RecuperaIdUsuario(HttpRequest request)
        {
            if (!request.Headers.TryGetValue("authorization", out StringValues token) ||
                   string.IsNullOrEmpty(token[0]))
            {
                return 0;
            }

            int usuarioId = _jwtHelper.RecuperaIdUsuario(token[0]?.Replace("bearer ", string.Empty));
            return usuarioId;
        }
    }
}
