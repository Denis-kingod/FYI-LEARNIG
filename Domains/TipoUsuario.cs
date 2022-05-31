using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace tcc_dbfyi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe o título do tipo de usuário!!!!")]
        public string Titulo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
