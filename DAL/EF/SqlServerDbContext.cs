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
        modelBuilder.Entity<ColumnBlock>()
                    .HasKey(t=>t.Id);

        modelBuilder.Entity<ColumnMeta>()
                    .HasKey(t => t.Id);

        modelBuilder.Entity<ColumnMeta>()
                    .HasOne(p => p.ColumnBlock)
                    .WithMany(b => b.ColumnMetas)
                    .HasForeignKey(p => p.ColumnBlockId);

        modelBuilder.Entity<ColumnValue>()
                    .HasKey(p => p.ColumnMetaId);

        modelBuilder.Entity<ColumnValue>()
                    .HasOne(p => p.ColumnMeta)
                    .WithOne(b => b.ColumnValue)
                    .HasForeignKey<ColumnValue>(p => p.ColumnMetaId);

    }
}
}
