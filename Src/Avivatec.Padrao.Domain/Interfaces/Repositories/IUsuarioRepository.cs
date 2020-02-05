using Avivatec.Padrao.Domain.Models;
using System.Collections.Generic;

namespace Avivatec.Padrao.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Login(Usuario request);

        Usuario Adicionar(Usuario request);

        Usuario Editar(Usuario request);

        Usuario Deletar(Usuario request);

        Usuario Obter(Usuario request);

        IEnumerable<Usuario> Listar(Usuario request);
    }
}
