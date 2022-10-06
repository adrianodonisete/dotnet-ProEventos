using Microsoft.EntityFrameworkCore;

using ProEventos.Domain;

namespace ProEventos.Persistence.Context
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<PalestranteEvento>()
                .HasKey(pe => new { pe.EventoId, pe.PalestranteId });

            mb.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rede => rede.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Palestrante>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rede => rede.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}