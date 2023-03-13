using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IEventoRepository
    {
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante);
    }
}