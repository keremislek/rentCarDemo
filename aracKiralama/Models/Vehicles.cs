namespace aracKiralama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vehicles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicles()
        {
            Rentals = new HashSet<Rentals>();
            Extras = new HashSet<Extras>();
        }

        [Key]
        public int AracID { get; set; }

        [Required]
        [StringLength(100)]
        public string AracAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string AracModeli { get; set; }

        public int AracYili { get; set; }

        public decimal KiralamaFiyati { get; set; }

        public int? AracSahibiID { get; set; }

        public byte[] AracResim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rentals> Rentals { get; set; }

        public virtual VehicleOwners VehicleOwners { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Extras> Extras { get; set; }
    }
}
