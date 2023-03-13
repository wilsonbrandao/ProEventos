using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Lote
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}