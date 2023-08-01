namespace aracKiralama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleOwners
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleOwners()
        {
            Vehicles = new HashSet<Vehicles>();
        }

        [Key]
        public int SahipID { get; set; }

        [Required]
        [StringLength(100)]
        public string SahipAdi { get; set; }

        [Required]
        [StringLength(20)]
        public string SahipTelefon { get; set; }

        [Required]
        [StringLength(100)]
        public string SirketAdi { get; set; }

        [Required]
        [StringLength(200)]
        public string SirketAdresi { get; set; }

        public int? KullaniciID { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
