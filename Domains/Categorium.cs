using System;
using System.Collections.Generic;

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
        public string Titulo { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
