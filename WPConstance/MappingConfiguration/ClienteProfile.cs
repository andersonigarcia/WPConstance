using AutoMapper;
using ConstanceRepo.Domain;
using ConstanceRepo.Dtos.Command;
using ConstanceRepo.Dtos.ViewModel;
using System.Linq;

namespace WPConstance.MappingConfiguration
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<EstadoCommand, Estado>();
            CreateMap<ClienteCommand, Cliente>();
            CreateMap<Telefone, TelefoneViewModel>();

            CreateMap<Cliente, ClienteViewModel>().
                ConvertUsing((source, context) => new ClienteViewModel
                {
                    Nome = source.Nome,
                    CPF = source.CPF,
                    Nascimento = source.Nascimento,
                    Estado = new EstadoViewModel
                    {
                        Nome = source.Estado.Nome,
                        Sigla = source.Estado.Sigla
                    },
                    Telefones = source.Telefone.Select(v => new TelefoneViewModel
                    {
                        Numero = v.Numero,
                        Tipo = v.Tipo.ToString()
                    }).ToList()
                });
        }
    }
}

