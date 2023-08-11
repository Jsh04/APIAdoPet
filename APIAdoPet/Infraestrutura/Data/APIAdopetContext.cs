using APIAdoPet.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIAdoPet.Infraestrutura.Data;

public class APIAdopetContext : IdentityDbContext<Usuario>
{
    public APIAdopetContext(DbContextOptions<APIAdopetContext> opts) : base(opts)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Tutor>().Property(t => t.Telefone).HasDefaultValue("");
        modelBuilder.Entity<Tutor>().Property(t => t.Foto).HasDefaultValue("");
    }

    public DbSet<Tutor> Tutores { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Abrigo> Abrigo { get; set; }
    public DbSet<Adocao> Adocaos { get; set; }
}
