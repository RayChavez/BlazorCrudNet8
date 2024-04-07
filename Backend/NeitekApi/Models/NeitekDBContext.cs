using Microsoft.EntityFrameworkCore;
using NeitekApi.Models;

namespace NeitekApi.Models
{
    public class NeitekDBContext: DbContext
    {

        public NeitekDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Metas> Metas => Set<Metas>();
        public  DbSet<Tareas> Tareas => Set<Tareas>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tareas>(c =>
            {
                c.HasKey(e => e.Id).HasName("FK_Tareas_Metas");
                c.ToTable("Tareas");
                c.HasOne(a => a.IdMetaNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdMeta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tareas_Metas");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
