using Microsoft.EntityFrameworkCore;

namespace CArch_V1.Models
{
    public class DbContexCArch2025 : DbContext
    {
        public DbContexCArch2025() { }
        public DbContexCArch2025(DbContextOptions<DbContexCArch2025> options) : base(options) { }

        public virtual DbSet<Tm_User> Tm_User { get; set; }
        public virtual DbSet<Tm_Portfolio> Tm_Portfolio { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

        //    modelBuilder.Entity<Tm_User>(entity =>
        //    {
        //        entity.ToTable("tm_user");

        //        entity.HasKey(e => e.Id);

        //        entity.Property(e => e.Username)
        //            .HasMaxLength(255);

        //        entity.Property(e => e.Password)
        //            .HasMaxLength(255);

        //        entity.Property(e => e.IsActive);
        //    });
        //}
    }
}
