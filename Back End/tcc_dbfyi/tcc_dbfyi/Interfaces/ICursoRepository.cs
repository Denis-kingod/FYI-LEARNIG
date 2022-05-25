using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Domains;

namespace tcc_dbfyi.Interfaces
{
    public interface ICursoRepository
    {
        List<Curso> Listar();

        void Cadastrar(Curso novoCurso);

        void Atualizar(int id, Curso CursoAtualizado);

        void Deletar(int id);

        Curso BuscarPorId(int id);

        Curso BuscarPorCategoria(int idCategoria);

    }
}
