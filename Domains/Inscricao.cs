using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace tcc_dbfyi.Domains
{
    public partial class Inscricao
    {
        public int IdInscricao { get; set; }

        [Required(ErrorMessage = "Informe o ID do usuário o qual pertence esta inscrição!!!!")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o ID da turma a qual pertence esta inscrição!!!!")]
        public int? IdTurma { get; set; }

        [Required(ErrorMessage = "Insira a data de inscrição!!!!")]
        [DataType(DataType.Date)]
        public DateTime? DataInscricao { get; set; }

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
