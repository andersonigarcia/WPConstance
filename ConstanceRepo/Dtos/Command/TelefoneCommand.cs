using ConstanceRepo.ValueObjects;

namespace ConstanceRepo.Dtos.Command
{
    public class TelefoneCommand
    {
        public long Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
    }
}
