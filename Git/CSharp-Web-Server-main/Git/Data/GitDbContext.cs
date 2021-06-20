using Git.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Data
{
    public class GitDbContext : DbContext
    {
        public GitDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<Repository> Repositories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=WebExamGit;Integrated Security = True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

    }
}
