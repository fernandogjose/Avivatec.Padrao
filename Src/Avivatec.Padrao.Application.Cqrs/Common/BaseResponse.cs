using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Avivatec.Padrao.Application.Cqrs.Common
{
    public class BaseResponse
    {
        
        public BaseResponse(Guid correlationId, HttpStatusCode statusCode, IEnumerable<string> erros = null, object data = null)
        {
            CorrelationId = correlationId;
            StatusCode = statusCode;
            Erros = erros?.ToList()?.AsReadOnly();
            Data = data;
        }

        public Guid CorrelationId { get; }
        public HttpStatusCode StatusCode { get; }
        public IReadOnlyCollection<string> Erros { get; }
        public object Data { get; set; }
    }
}
