namespace aracKiralama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payments
    {
        [Key]
        public int OdemeID { get; set; }

        public int? KiralamaID { get; set; }

        [Column(TypeName = "date")]
        public DateTime OdemeTarihi { get; set; }

        public decimal OdemeMiktari { get; set; }

        public virtual Rentals Rentals { get; set; }
    }
}
