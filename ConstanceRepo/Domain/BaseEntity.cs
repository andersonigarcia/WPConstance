using System;

namespace ConstanceRepo.Domain
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Ativo { get; set; }
    }
}
