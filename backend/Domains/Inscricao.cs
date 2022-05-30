using System;
using System.Collections.Generic;

#nullable disable

namespace tcc_dbfyi.Domains
{
    public partial class Inscricao
    {
        public int IdInscricao { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTurma { get; set; }
        public DateTime? DataInscricao { get; set; }

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
