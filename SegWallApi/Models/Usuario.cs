using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegWallApi.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        [StringLength(250, ErrorMessage = "Seu nome deve conter no máximo 250 caracateres")]
        [Column("NOME")]
        public String Nome { get; set; }

        [Column("DATANASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("SEXO")]
        public String Sexo { get; set; }

        public virtual IList<Apolice> Apolices { get; set; }
    }
}
