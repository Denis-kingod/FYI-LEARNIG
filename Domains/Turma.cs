using System;
using System.Collections.Generic;

#nullable disable

namespace tcc_dbfyi.Domains
{
    public partial class Turma
    {
        public Turma()
        {
            Inscricaos = new HashSet<Inscricao>();
        }

        public int IdTurma { get; set; }
        public int? IdCurso { get; set; }
        public string NomeTurma { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<Inscricao> Inscricaos { get; set; }
    }
}
