using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestranteRepository
    {
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEvento = false);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEvento = false);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEvento = false);
    }
}