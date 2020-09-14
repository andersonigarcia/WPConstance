using System;
using System.Collections.Generic;

namespace ConstanceRepo.Domain
{
    public class Cliente : BaseEntity
    {
        public string  Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public long EstadoId { get; set; }
        public virtual Estado Estado { get; set; }        
        public virtual List<Telefone> Telefone { get; set; }

    }
}
