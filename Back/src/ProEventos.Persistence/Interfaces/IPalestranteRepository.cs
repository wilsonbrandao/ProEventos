using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestranteRepository
    {
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEvento);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEvento);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEvento);
    }
}