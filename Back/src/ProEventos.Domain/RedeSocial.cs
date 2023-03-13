using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class RedeSocial
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URl { get; set; }
        public int? EventoId { get; set; }
        public Evento evento { get; set; }
        public int? PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}