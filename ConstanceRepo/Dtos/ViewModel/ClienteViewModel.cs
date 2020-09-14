using System;
using System.Collections.Generic;

namespace ConstanceRepo.Dtos.ViewModel
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public EstadoViewModel Estado { get; set; }
        public ICollection<TelefoneViewModel> Telefones { get; set; }
    }
}
