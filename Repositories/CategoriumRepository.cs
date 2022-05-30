using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Context;
using tcc_dbfyi.Domains;
using tcc_dbfyi.Interfaces;

namespace tcc_dbfyi.Repositories
{
    public class CategoriumRepository : ICategoriumRepository
    {
        DBFYIContext ctx = new DBFYIContext();
        public void Atualizar(int id, Categorium CategoriaAtualizada)
        {
            Categorium CategoriaProcurada = ctx.Categoria.Find(id);

            if (CategoriaAtualizada.Titulo != null)
            {
                CategoriaProcurada.Titulo = CategoriaAtualizada.Titulo;
            }
            ctx.Categoria.Update(CategoriaProcurada);

            ctx.SaveChanges();
        }

        public Categorium BuscarPorId(int id)
        {
            return ctx.Categoria.FirstOrDefault(e => e.IdCategoria == id);
        }

        public Categorium BuscarPorTitulo(string titulo)
        {
            return ctx.Categoria.FirstOrDefault(k => k.Titulo == titulo);
        }

        public void Cadastrar(Categorium novaCategoria)
        {
            ctx.Categoria.Update(novaCategoria);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Categoria.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Categorium> Listar()
        {
            return ctx.Categoria.ToList();
        }
    }
}
