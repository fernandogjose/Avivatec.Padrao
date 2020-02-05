using Avivatec.Padrao.Domain.Interfaces.Repositories;
using Avivatec.Padrao.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Avivatec.Padrao.Domain.Validacoes
{
    public class UsuarioValidacao
    {
        public UsuarioValidacao(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        private readonly IUsuarioRepository _usuarioRepository;

        public List<Erro> Erros { get; private set; }

        private void LimpaErros()
        {
            Erros = new List<Erro>();
        }

        private void AdicionarErro(int codigoErro, string mensagemErro)
        {
            Erros.Add(new Erro
            {
                Codigo = codigoErro,
                Descricao = mensagemErro
            });
        }

        private void ValidarEmailJaCadastrado(Usuario request)
        {
            IEnumerable<Usuario> usuarios = _usuarioRepository.Listar(request);

            if (usuarios.Any(x => x.Id != request.Id))
                AdicionarErro(400, "E-mail já cadastrado");
        }

        public bool TemErros()
        {
            return Erros != null && Erros.Any();
        }
    }
}