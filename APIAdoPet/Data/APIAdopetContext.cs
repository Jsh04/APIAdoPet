using APIAdoPet.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAdoPet.Data;

public class APIAdopetContext : DbContext
{
    public APIAdopetContext(DbContextOptions<APIAdopetContext> opts) : base(opts)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tutor>().Property(t => t.Telefone).HasDefaultValue("");
        modelBuilder.Entity<Tutor>().Property(t => t.Foto).HasDefaultValue("");
    }

    public DbSet<Tutor> Tutores { get; set; }
}
