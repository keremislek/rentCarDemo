namespace aracKiralama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers()
        {
            Rentals = new HashSet<Rentals>();
        }

        [Key]
        public int MusteriID { get; set; }

        [Required]
        [StringLength(100)]
        public string MusteriAdi { get; set; }

        [Required]
        [StringLength(20)]
        public string MusteriTelefon { get; set; }

        [Required]
        [StringLength(200)]
        public string MusteriAdres { get; set; }

        public int? KullaniciID { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rentals> Rentals { get; set; }
    }
}
