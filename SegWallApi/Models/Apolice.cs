using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegWallApi.Models
{
    [Table("APOLICE")]
    public class Apolice
    {
        [Key]
        [Column("IDAPOLICE")]
        public int IdApolice { get; set; }

        [Column("NUMEROAPOLICE")]
        public String Numero { get; set; }

        [Column("TIPOAPOLICE")]
        public String TipoApolice { get; set; }

        [Required(ErrorMessage = "Data Inicio obrigatória!")]
        [Column("DATAINICIO")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Data Fim obrigatória!")]
        [Column("DATAFIM")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "Usuário obrigatório!")]
        [ForeignKey("IDUSUARIO")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Seguro obrigatório!")]
        [ForeignKey("IDSEGURO")]
        public int IdSeguro { get; set; }
        public virtual Seguro Seguro { get; set; }

    }
}
