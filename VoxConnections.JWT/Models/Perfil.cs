using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoxConnections.JWT.Models
{
    public class Perfil
    {
        public Guid IdUsuario { get; set; }
    }

    [Table("tb_Candidato")]
    public class Candidato : Perfil
    {
        [Key]
        public int IdCandidato { get; set; }
    }

    [Table("tb_Gestor")]
    public class Gestor : Perfil
    {
        [Key]
        public int IdGestor { get; set; }
    }

    [Table("tb_Headhunter")]
    public class Headhunter : Perfil
    {
        [Key]
        public int IdHeadhunter { get; set; }
    }
}
