namespace aracKiralama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rentals
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rentals()
        {
            Payments = new HashSet<Payments>();
        }

        [Key]
        public int KiralamaID { get; set; }

        public int? MusteriID { get; set; }

        public int? AracID { get; set; }

        [Column(TypeName = "date")]
        public DateTime KiralamaTarihi { get; set; }

        [Column(TypeName = "date")]
        public DateTime IadeTarihi { get; set; }

        public decimal ToplamFiyat { get; set; }

        public virtual Customers Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payments> Payments { get; set; }

        public virtual Vehicles Vehicles { get; set; }
    }
}
