using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }
        public DbSet<Column> Columns { get; set; }
        public DbSet<ColumnBlock> ColumnBlocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
