using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class PalestranteRepository : IPalestranteRepository
    {
        private readonly ProEventosContext _context;

        public PalestranteRepository(ProEventosContext context)
        {
            _context = context;

        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
           .Include(palestrante => palestrante.RedeSociais);

            if (includeEvento)
            {
                //include relations on JSON returned
                query
                .Include(palestrante => palestrante.PalestranteEventos)
                .ThenInclude(palestranteEventos => palestranteEventos.Evento);
            }

            query = query
            .AsNoTracking()
            .OrderBy(palestrante => palestrante.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
          .Include(palestrante => palestrante.RedeSociais);

            if (includeEvento)
            {
                //include relations on JSON returned
                query
                .Include(palestrante => palestrante.PalestranteEventos)
                .ThenInclude(palestranteEventos => palestranteEventos.Evento);
            }

            query = query
            .AsNoTracking()
            .OrderBy(palestrante => palestrante.Id)
            .Where(palestrante => palestrante.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(palestrante => palestrante.RedeSociais);

            if (includeEvento)
            {
                //include relations on JSON returned
                query
                .Include(palestrante => palestrante.PalestranteEventos)
                .ThenInclude(palestranteEventos => palestranteEventos.Evento);
            }

            query = query
            .AsNoTracking()
            .OrderBy(palestrante => palestrante.Id)
            .Where(palestrante => palestrante.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}