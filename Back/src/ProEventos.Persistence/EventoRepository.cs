using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ProEventosContext _context;

        public EventoRepository(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(evento => evento.Lotes)
            .Include(evento => evento.RedeSociais);

            query = query.OrderBy(evento => evento.Id);

            if (includePalestrante)
            {
                //include relations on JSON returned
                query
                .Include(evento => evento.PalestranteEventos)
                .ThenInclude(palestranteEventos => palestranteEventos.Palestrante);
            }
            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(evento => evento.Lotes)
            .Include(evento => evento.RedeSociais);

            query = query.OrderBy(evento => evento.Id)
            .Where(evento => evento.Tema.ToLower().Contains(tema.ToLower()));

            if (includePalestrante)
            {
                //include relations on JSON returned
                query
                .Include(evento => evento.PalestranteEventos)
                .ThenInclude(palestranteEventos => palestranteEventos.Palestrante);
            }
            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(evento => evento.Lotes)
            .Include(evento => evento.RedeSociais);

            query = query.OrderBy(evento => evento.Id)
            .Where(evento => evento.Id == eventoId);

            if (includePalestrante)
            {
                //include relations on JSON returned
                query
                .Include(evento => evento.PalestranteEventos)
                .ThenInclude(palestranteEventos => palestranteEventos.Palestrante);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}