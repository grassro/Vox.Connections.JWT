using VoxConnections.JWT.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoxConnections.JWT.Models
{
    [Table("tb_Usuario")]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public EnumTipoUsuario TipoUsuario { get; set; }
        public bool Cadastrado { get; set; }
    }
}
