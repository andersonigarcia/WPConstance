using ConstanceRepo.ValueObjects;

namespace WPConstance.Dtos.Command
{
    public class TelefoneCommand
    {
        public long Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
    }
}
