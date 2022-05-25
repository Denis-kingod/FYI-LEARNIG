using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Context;
using tcc_dbfyi.Domains;
using tcc_dbfyi.Interfaces;

namespace tcc_dbfyi.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        DBFYIContext ctx = new DBFYIContext();
        public void Atualizar(int id, Curso CursoAtualizado)
        {
            Curso CursoProcurado = ctx.Cursos.Find(id);

            if (CursoAtualizado.NomeCurso != null)
            {
                CursoProcurado.NomeCurso = CursoAtualizado.NomeCurso;
            }

            if (CursoProcurado.Descricao != null)
            {
                CursoProcurado.Descricao = CursoAtualizado.Descricao;
            }

            if (CursoProcurado.CargaHoraria != null)
            {
                CursoProcurado.CargaHoraria = CursoAtualizado.CargaHoraria;
            }


            ctx.Cursos.Update(CursoProcurado);

            ctx.SaveChanges();
        }

        public Curso BuscarPorCategoria(int idCategoria)
        {
            return ctx.Cursos.FirstOrDefault(k => k.IdCategoriaNavigation.IdCategoria == idCategoria);
        }

        public Curso BuscarPorId(int id)
        {
            return ctx.Cursos.FirstOrDefault(e => e.IdCurso == id);
        }


        public void Cadastrar(Curso novoCurso)
        {
            ctx.Cursos.Update(novoCurso);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Cursos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Curso> Listar()
        {
            return ctx.Cursos.ToList();
        }
    }
}
