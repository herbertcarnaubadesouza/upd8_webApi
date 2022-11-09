using AutoMapper;
using upd8_webApi.DTO.Resposta;
using upd8_webApi.DTO.Solicitação;
using upd8_webApi.Models;

namespace upd8_webApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {            
            CreateMap<Cidade, CidadeDTO>();
            CreateMap<CidadeDTO, Cidade>(); 
            CreateMap<CidadeSolicitacaoDto, Cidade>();

            CreateMap<Estado, EstadoDTO>();
            CreateMap<EstadoDTO, Estado>();
            CreateMap<EstadoSolicitacaoDto, Estado>();

            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Cliente, ClienteDTO>();
        }
    }
}
