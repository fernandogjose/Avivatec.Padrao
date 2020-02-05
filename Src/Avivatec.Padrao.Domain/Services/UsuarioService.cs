using Avivatec.Padrao.Domain.Interfaces.Repositories;
using Avivatec.Padrao.Domain.Interfaces.Services;
using Avivatec.Padrao.Domain.Models;
using Avivatec.Padrao.Domain.Validacoes;
using System;
using System.Collections.Generic;

namespace Avivatec.Padrao.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        public UsuarioService(IUsuarioRepository usuarioRepository, UsuarioValidacao usuarioValidacao)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioValidacao = usuarioValidacao;
        }

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UsuarioValidacao _usuarioValidacao;

        public Usuario Login(Usuario request)
        {
            Usuario response = _usuarioRepository.Login(request);
            return response;
        }

        public Usuario Adicionar(Usuario request)
        {
            throw new NotImplementedException();
        }

        public Usuario Editar(Usuario request)
        {
            throw new NotImplementedException();
        }

        public Usuario Deletar(Usuario request)
        {
            throw new NotImplementedException();
        }

        public Usuario Obter(Usuario request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Listar(Usuario request)
        {
            throw new NotImplementedException();
        }
    }
}
