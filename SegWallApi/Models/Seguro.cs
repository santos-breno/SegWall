using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegWallApi.Models
{
    [Table("SEGURO")]
    public class Seguro
    {
        [Key]
        [Column("IDSEGURO")]
        public int IdSeguro { get; set; }

        [Column("TIPOSEGURO")]
        public String TipoSeguro { get; set; }

        public virtual List<Apolice> Apolices { get; set; }
    }
}
