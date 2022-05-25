using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Context;
using tcc_dbfyi.Domains;
using tcc_dbfyi.Interfaces;

namespace tcc_dbfyi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        DBFYIContext ctx = new DBFYIContext();

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioProcurado = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(tipoUsuarioProcurado);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioProcurado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioAtualizado.Titulo != null)
            {
                tipoUsuarioProcurado.Titulo = tipoUsuarioAtualizado.Titulo;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioProcurado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

    }
}
