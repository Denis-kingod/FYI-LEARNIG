using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Domains;

namespace tcc_dbfyi.Interfaces
{
    public interface ITurmaRepository
    {
        List<Turma> Listar();

        void Cadastrar(Turma novaTurma);

        void Deletar(int id);

        void Atualizar(int id, Turma turmaAtualizada);

        Turma BuscarPorId(int id);

        Turma BuscarPorCurso(int idCurso);
    }
}
