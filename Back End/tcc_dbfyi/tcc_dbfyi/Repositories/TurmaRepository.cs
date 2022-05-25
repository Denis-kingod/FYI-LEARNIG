using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Context;
using tcc_dbfyi.Domains;
using tcc_dbfyi.Interfaces;

namespace tcc_dbfyi.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        DBFYIContext ctx = new DBFYIContext();

        public void Atualizar(int id, Turma turmaAtualizada)
        {
            Turma turmaProcurada = ctx.Turmas.Find(id);

            if (turmaAtualizada.IdCurso != null)
            {
                turmaProcurada.IdCurso = turmaAtualizada.IdCurso;
            }

            if (turmaAtualizada.NomeTurma != null)
            {
                turmaProcurada.NomeTurma = turmaAtualizada.NomeTurma;
            }

            ctx.Turmas.Update(turmaProcurada);

            ctx.SaveChanges();
        }

        public Turma BuscarPorCurso(int idCurso)
        {
            return ctx.Turmas.FirstOrDefault(en => en.IdCursoNavigation.IdCurso == idCurso);
        }

        public Turma BuscarPorId(int id)
        {
            return ctx.Turmas.FirstOrDefault(tu => tu.IdTurma == id);
        }

        public void Cadastrar(Turma novaTurma)
        {
            ctx.Turmas.Add(novaTurma);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Turma turmaBuscada = ctx.Turmas.Find(id);

            ctx.Turmas.Remove(turmaBuscada);

            ctx.SaveChanges();
        }

        public List<Turma> Listar()
        {
            return ctx.Turmas.ToList();
        }
    }
}
