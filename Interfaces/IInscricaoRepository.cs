using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Domains;

namespace tcc_dbfyi.Interfaces
{
    public interface IInscricaoRepository
    {
        List<Inscricao> Listar();

        List<Inscricao> ListarProprias(int idUsuario);

        void Cadastrar(Inscricao novaInscricao);

        void Deletar(int id);

        void Atualizar(int id, Inscricao inscricaoAtualizada);

        Inscricao BuscarPorId(int id);

        Inscricao BuscarPorTurma(int id);
    }
}
