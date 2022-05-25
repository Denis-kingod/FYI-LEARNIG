using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Domains;

namespace tcc_dbfyi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        List<Usuario> Listar();

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id, Usuario usuarioAtualizado);

        void Deletar(int id);

        Usuario BuscarPorId(int id);

        Usuario BuscarPorEmail(string Email);
    }
}
