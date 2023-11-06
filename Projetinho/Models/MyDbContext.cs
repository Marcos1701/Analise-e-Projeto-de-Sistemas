using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projetinho.Models;

namespace Projetinho.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
       {
       }

        public DbSet<Member> Members {get; set;} = null!;
        public DbSet<Libraian> Libraians {get; set;} = null!;
        public DbSet<Books> Books {get; set;} = null!;
        public DbSet<Catalog> Catalogs {get; set;} = null!;
        public DbSet<FacultyMember> FacultyMembers {get; set;} = null!;
        public DbSet<GeneralBook> GeneralBooks {get; set;} = null!;
        public DbSet<ReferenceBook> ReferenceBooks {get; set;} = null!;
        public DbSet<Student> Student {get; set;} = null!;
        public DbSet<Alert> Alert {get; set;} = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasMany(m => m.Libraians)
                .WithMany(l => l.Members);

            modelBuilder.Entity<Member>()
                .HasMany(m => m.GeneralBooks)
                .WithOne(b => b.Member);

            modelBuilder.Entity<Books>()
                .HasOne(b => b.Catalog)
                .WithMany(c => c.Books);

            modelBuilder.Entity<Libraian>()
                .HasMany(l => l.Books)
                .WithOne(b => b.Libraian);
        }
    }
}