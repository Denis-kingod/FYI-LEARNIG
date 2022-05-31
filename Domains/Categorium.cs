using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace tcc_dbfyi.Domains
{
    public partial class Categorium
    {
        public Categorium()
        {
            Cursos = new HashSet<Curso>();
        }

        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Insira o título da categoria!!!!")]
        public string Titulo { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
