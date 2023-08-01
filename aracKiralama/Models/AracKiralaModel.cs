using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace aracKiralama.Models
{
    public partial class AracKiralaModel : DbContext
    {
        public AracKiralaModel()
            : base("name=AracKiralaModel")
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Extras> Extras { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Rentals> Rentals { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VehicleOwners> VehicleOwners { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>()
                .Property(e => e.SehirAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.MusteriAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.MusteriTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.MusteriAdres)
                .IsUnicode(false);

            modelBuilder.Entity<Extras>()
                .Property(e => e.EkstraAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Extras>()
                .Property(e => e.EkstraFiyati)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Payments>()
                .Property(e => e.OdemeMiktari)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Rentals>()
                .Property(e => e.ToplamFiyat)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Roles>()
                .Property(e => e.RolAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.KullaniciAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Sifre)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Eposta)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleOwners>()
                .Property(e => e.SahipAdi)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleOwners>()
                .Property(e => e.SahipTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleOwners>()
                .Property(e => e.SirketAdi)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleOwners>()
                .Property(e => e.SirketAdresi)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleOwners>()
                .HasMany(e => e.Vehicles)
                .WithOptional(e => e.VehicleOwners)
                .HasForeignKey(e => e.AracSahibiID);

            modelBuilder.Entity<Vehicles>()
                .Property(e => e.AracAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicles>()
                .Property(e => e.AracModeli)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicles>()
                .Property(e => e.KiralamaFiyati)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Vehicles>()
                .HasMany(e => e.Extras)
                .WithMany(e => e.Vehicles)
                .Map(m => m.ToTable("VehicleExtras").MapLeftKey("AracID").MapRightKey("EkstraID"));
        }
    }
}
