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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
            //.haskey set the primary key
            //The EF recognizes the evento and palestrante foreign key by convention
            .HasKey(palestranteEvento => 
            new { palestranteEvento.EventoId, palestranteEvento.PalestranteId });
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }
    }
}