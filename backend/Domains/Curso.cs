using System;
using System.Collections.Generic;

#nullable disable

namespace tcc_dbfyi.Domains
{
    public partial class Curso
    {
        public Curso()
        {
            Turmas = new HashSet<Turma>();
        }

        public int IdCurso { get; set; }
        public int? IdCategoria { get; set; }
        public string NomeCurso { get; set; }
        public string Descricao { get; set; }
        public string VagasDisponiveis { get; set; }
        public string VagasPreenchidas { get; set; }
        public string CargaHoraria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
