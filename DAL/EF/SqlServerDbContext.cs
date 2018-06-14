using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }

        public DbSet<ColumnBlock> ColumnBlock { get; set; }
        public DbSet<ColumnMeta> ColumnMeta { get; set; }
        public DbSet<ColumnValue> ColumnValue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
