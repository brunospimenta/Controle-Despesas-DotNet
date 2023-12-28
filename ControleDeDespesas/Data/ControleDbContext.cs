using ControleDeDespesas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControleDeDespesas.Data
{
    public class ControleDbContext : IdentityDbContext<Usuario, Role, int>
    {
        public ControleDbContext(DbContextOptions<ControleDbContext> opts): base(opts) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RoleId);

            builder.Entity<Despesa>()
                .HasOne(d => d.Usuario)
                .WithMany(u => u.Despesas)
                .HasForeignKey(d => d.UsuarioId);

            builder.Entity<Planejamento>()
                .HasOne(p => p.Usuario)
                .WithMany(d => d.Planejamentos)
                .HasForeignKey(p => p.UsuarioId);

            builder.Entity<Despesa>()
                .HasOne(d => d.Planejamento)
                .WithMany(p => p.Despesa)
                .HasForeignKey(d => d.PlanejamentoId);

            builder.Entity<Conta>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.Conta)
                .HasForeignKey<Conta>(c => c.UsuarioId);
                //.OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Planejamento> Planejamentos { get; set; }
        public DbSet<Conta> Contas { get; set; }

    }
}
