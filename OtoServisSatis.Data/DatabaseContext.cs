using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OtoServisSatis.Entities;


namespace OtoServisSatis.Data
{
    public class DatabaseContext :DbContext

    {
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }          
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }  
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-ML8F0M1; database=OtoServisSatis; TrustServerCertificate=True;
            integrated security=True; MultipleActiveResultSets=True;");
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<Marka>().Property(m=>m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m=>m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Adi = "Admin"
            });

            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
               Id = 1,
               Adi = "Admin",
               AktifMi = true,
               EklenmeTarihi = DateTime.Now,
               Email = "admin@otoservissatiis.tc",
               KullaniciAdi = "admin",
               Sifre = "123456",
               //Rol = new Rol { Id = 1 },
               RolId = 1,
               SoyAdi = "admin",
               Telefon = "0850",

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
