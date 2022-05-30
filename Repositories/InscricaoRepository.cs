using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Context;
using tcc_dbfyi.Domains;
using tcc_dbfyi.Interfaces;

namespace tcc_dbfyi.Repositories
{
    public class InscricaoRepository : IInscricaoRepository
    {
        DBFYIContext ctx = new DBFYIContext();

        public void Atualizar(int id, Inscricao inscricaoAtualizada)
        {
            Inscricao inscricaoProcurada = ctx.Inscricaos.Find(id);

            if (inscricaoAtualizada.DataInscricao != null)
            {
                inscricaoProcurada.DataInscricao = inscricaoAtualizada.DataInscricao;
            }

            if (inscricaoProcurada.IdTurma != null)
            {
                inscricaoProcurada.IdTurma = inscricaoAtualizada.IdTurma;
            }

            ctx.Inscricaos.Update(inscricaoProcurada);

            ctx.SaveChanges();
        }

        public Inscricao BuscarPorId(int id)
        {
            return ctx.Inscricaos.FirstOrDefault(tu => tu.IdInscricao == id);
        }

        public Inscricao BuscarPorTurma(int id)
        {
            return ctx.Inscricaos.FirstOrDefault(tu => tu.IdTurmaNavigation.IdTurma == id);
        }

        public void Cadastrar(Inscricao novaInscricao)
        {
            ctx.Inscricaos.Add(novaInscricao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Inscricao inscricaoBuscada = ctx.Inscricaos.Find(id);

            ctx.Inscricaos.Remove(inscricaoBuscada);

            ctx.SaveChanges();
        }

        public List<Inscricao> Listar()
        {
            return ctx.Inscricaos.ToList();
        }

        public List<Inscricao> ListarProprias(int idUsuario)
        {
            return ctx.Inscricaos
                .Include(u => u.IdUsuarioNavigation)
                .Include(u => u.IdTurmaNavigation.IdCursoNavigation)
                .Include(u => u.IdTurmaNavigation)
                .Where(u => u.IdUsuario == idUsuario)
                .ToList();
        }
    }
}
