using Frigate.Infrastructure.DbImplementation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Infrastructure.DbImplementation
{
    public class FrigateDbContext : DbContext
    {
        private readonly string connectionString;
        public FrigateDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString);
        }

        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<SemanticView> SemanticViews { get; set; }
        public DbSet<DataSourceDetails> datasourcedetail { get; set; }
        public DbSet<SemanticViewDetails> SemanticViewDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TestTable>(tt =>
            {
                tt.HasKey(x => x.TestTableId);
            });

            builder.Entity<SemanticView>(sv =>
            {
                sv.HasKey(x => x.dashboardId);
            });

            builder.Entity<SemanticViewDetails>(svd =>
            {
                svd.HasKey(x => x.SemanticViewDetailsId);
            });
            builder.Entity<DataSourceDetails>(svd =>
            {
                svd.HasKey(x => x.Id);
            });
        }
    }
}
