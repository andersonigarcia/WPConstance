using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConstanceRepo.Dtos.Command
{
    public class ClienteCommand
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime Nascimento { get; set; }
        public long EstadoId { get; set; }
        [Required]
        public long IdEstado { get; set; }
        [Required]
        public List<TelefoneCommand> Telefone { get; set; }
    }
}
