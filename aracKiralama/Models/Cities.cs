namespace aracKiralama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cities
    {
        [Key]
        public int SehirID { get; set; }

        [Required]
        [StringLength(100)]
        public string SehirAdi { get; set; }
    }
}
