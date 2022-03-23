using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using DuzMvc.Models;
using DuzMvc.Dal.DumduzInitializer;

namespace DuzMvc.Dal
{
    public class DuzDbContext:DbContext   // Context her zaman code first de db olarak mı kodlanır.
    {                                     // Burada tasinmazlarda ki her şey neden yazmıyor?Burası sadece primary key atamak için mi ?

        public DuzDbContext():base("DuzContext")
        {
            Database.SetInitializer(new DuzInitializer());
        }

        public DbSet<Sahip> Sahips { get; set; } // Burada ki taşınmaz taşınmazes muhabbetini sor ?? 

        public  DbSet<Tasinmaz> Tasinmazes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<Sahip>()
                .HasKey(s => s.Id) //Primary key atadık
                .Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Sahip>().Property(s => s.Name).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Sahip>().Property(s => s.Name).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Sahip>().Property(s => s.DTarih).HasColumnType("date");
            modelBuilder.Entity<Sahip>().Property(s => s.Idno).HasMaxLength(20);
            
            modelBuilder.Entity<Sahip>().Property(s => s.CreatedDate).HasColumnType("date");
            
            modelBuilder.Entity<Sahip>().Property(s => s.UpdatedDate).HasColumnType("date");

           

            modelBuilder.Entity<Tasinmaz>().Property(s => s.AlinisTarih).HasColumnType("date");

            modelBuilder.Entity<Tasinmaz>().Property(s => s.AlinisFiyat).HasPrecision(14,2);


            modelBuilder.Entity<Tasinmaz>().Property(s => s.CreatedDate).HasColumnType("date");

            modelBuilder.Entity<Tasinmaz>().Property(s => s.UpdatedDate).HasColumnType("date");



        }
    }
}