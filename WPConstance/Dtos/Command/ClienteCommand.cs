using System;
using System.Collections.Generic;

namespace ConstanceRepo.Dtos.Command
{
    public class ClienteCommand
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public long EstadoId { get; set; }
        public long IdEstado { get; set; }
        public List<TelefoneCommand> Telefone { get; set; }
    }
}
