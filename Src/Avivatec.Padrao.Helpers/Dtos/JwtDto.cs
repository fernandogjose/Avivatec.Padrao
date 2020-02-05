using System.Security.Claims;

namespace Avivatec.Padrao.Helpers.Dtos
{
    public class JwtDto
    {
        public ClaimsIdentity ClaimsIdentity { get; set; }

        public string ChaveSecreta { get; set; }

        public string EmissorDoToken { get; set; }

        public string DestinatarioDoToken { get; set; }

        public int DiasParaExpirar { get; set; }
    }
}
