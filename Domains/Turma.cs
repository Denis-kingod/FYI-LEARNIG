using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Informe o Id do curso o qual pertence esta turma!!!!")]
        public int? IdCurso { get; set; }

        [Required(ErrorMessage = "Informe o nome da turma!!!!")]
        public string NomeTurma { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<Inscricao> Inscricaos { get; set; }
    }
}
