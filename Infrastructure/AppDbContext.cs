
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext 
    {

        public DbSet<Student>? Students { get; set; }
        public DbSet<Subject>? Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAVEESHAM-BP\\MSSQLSERVER01;database=School;user=test;password=123;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                    .HasMany(e => e.Subjects)
                    .WithMany(e => e.Students)
                    .UsingEntity("StudentSubject");

        }


    }
}
