using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Informe o nome do curso!!!!")]
        public string NomeCurso { get; set; }

        [Required(ErrorMessage = "Insira a descrição, ela é necessária para a informação do aluno quanto ao curso!!!!")]
        [StringLength(2048)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Insira a quantidade de vagas restantes!!!!")]
        public string VagasDisponiveis { get; set; }

        [Required(ErrorMessage = "Insira a quantidade de vagas preenchidas!!!!")]
        public string VagasPreenchidas { get; set; }

        [Required(ErrorMessage = "Informe a duração do curso!!!!")]
        [DataType(DataType.Duration)]
        public string CargaHoraria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
