using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contexts
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext( DbContextOptions<ProEventosContext> options) : base(options)
        { 

        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
            //.haskey set the primary key
            //The EF recognizes the evento and palestrante foreign key by convention
            .HasKey(palestranteEvento => 
            new { palestranteEvento.EventoId, palestranteEvento.PalestranteId });

            modelBuilder.Entity<Evento>()
            .HasMany(evento => evento.RedeSociais)
            .WithOne(redeSocial => redeSocial.Evento)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
            .HasMany(palestrante => palestrante.RedeSociais)
            .WithOne(redeSocial => redeSocial.Palestrante)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}