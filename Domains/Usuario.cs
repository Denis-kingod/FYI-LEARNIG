using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Informe a qual tipo de usuário é pertencente esta pessoa!!!!")]
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Insira o nome do usuário!!!!")]
        public string Nome { get; set; }
        public string Empresa { get; set; }

        [Required(ErrorMessage = "Insira o email do usuário!!!!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira a senha do email!!!!")]
        [DataType(DataType.Password)]
        [StringLength(70, MinimumLength = 8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres!!!!")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Inscricao> Inscricaos { get; set; }
    }
}
