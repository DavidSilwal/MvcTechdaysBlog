﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcTechdaysBlog.Models
{
    public class DataService : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }

        public DataService() : base("ConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}