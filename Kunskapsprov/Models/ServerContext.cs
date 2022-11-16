using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kunskapsprov.Models
{
    public class ServerContext : DbContext
    {
        
        public ServerContext(DbContextOptions<ServerContext> options)
            : base(options)
        {

        }     
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost;database=LAPTOP-V4HVENUP\\SQLEXPRESS;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Person>(entity =>
            {
                

                entity.ToTable("person");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("Id");

                entity.Property(e => e.First_Name)
                    .HasColumnName("First_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.Last_Name)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.Adress)
                    .HasColumnName("Adress")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasMaxLength(255);

            });
            
        }
        
    }
}
