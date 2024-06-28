using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Statement> Statement { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<User> User { get; set; }
    }

}