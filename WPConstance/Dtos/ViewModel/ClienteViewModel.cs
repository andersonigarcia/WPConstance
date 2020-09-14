using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPConstance.Dtos.Command;

namespace WPConstance.Dtos.ViewModel
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        //public long IdEstado { get; set; }
        //public string SiglaEstado { get; set; }        
        //public List<TelefoneCommand> Telefone { get; set; }

    }
}
