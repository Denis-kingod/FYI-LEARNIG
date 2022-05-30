using System;
using System.Collections.Generic;

#nullable disable

namespace tcc_dbfyi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Inscricaos = new HashSet<Inscricao>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Inscricao> Inscricaos { get; set; }
    }
}
