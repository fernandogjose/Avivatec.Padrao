using System;
using System.Collections.Generic;

namespace Avivatec.Padrao.Domain.Models
{
    public abstract class Base
    {
        public Base()
        {
            Erros = new List<Erro>(0);
        }

        public int Id { get; set; }

        public int IdUsuarioCadastro { get; set; }

        public int IdUsuarioAlteracao { get; set; }

        public int IdUsuarioExclusao { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public List<Erro> Erros { get; protected set; }
    }
}
