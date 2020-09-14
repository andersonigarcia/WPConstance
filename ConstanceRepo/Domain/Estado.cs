using System.Collections.Generic;

namespace ConstanceRepo.Domain
{
    public class Estado : BaseEntity
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }        
        //public List<Cliente> Cliente { get; set; }
    }
}
