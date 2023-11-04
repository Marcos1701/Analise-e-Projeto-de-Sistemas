using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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


    }
}