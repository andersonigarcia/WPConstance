﻿using ConstanceRepo.ValueObjects;

namespace ConstanceRepo.Domain
{
    public class Telefone : BaseEntity
    {
        public long Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
