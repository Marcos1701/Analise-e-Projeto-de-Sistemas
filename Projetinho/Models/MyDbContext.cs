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
        public DbSet<LibraianMember> LibraianMembers {get; set;} = null!;
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
                .WithMany(l => l.Members)
                .UsingEntity<LibraianMember>(
                    j => j
                        .HasOne(lm => lm.Libraian)
                        .WithMany()
                        .HasForeignKey(lm => lm.LibraianId),
                    j => j
                        .HasOne(lm => lm.Member)
                        .WithMany()
                        .HasForeignKey(lm => lm.MemberId));

            modelBuilder.Entity<Member>()
                .HasMany(m => m.GeneralBooks)
                .WithOne(b => b.Member);

            modelBuilder.Entity<Books>()
                .HasOne(b => b.Catalog)
                .WithMany(c => c.Books);

            modelBuilder.Entity<Libraian>()
                .HasMany(l => l.Books)
                .WithOne(b => b.Libraian);

            modelBuilder.Entity<FacultyMember>()
                .HasOne(fm => fm.Libraian)
                .WithMany();
            
            modelBuilder.Entity<Student>()
                .HasOne(fm => fm.Libraian)
                .WithMany();
        }
    }
}