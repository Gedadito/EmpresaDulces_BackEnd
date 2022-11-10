using AutoMapper;
using EmpresaDulces.DTOs;
using EmpresaDulces.Entidades;

namespace EmpresaDulces.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TiposDeDulcesCreacionDTO, InformacionDulce>();
            CreateMap<InformacionDulce, TiposDeDulcesDTO>();
            CreateMap<InfoDulceCreacionDTO, Dulces>()
                .ForMember(dulce => dulce.DulceInfos, opciones => opciones.MapFrom(MapDulcesInfo));
            CreateMap<Dulces, InfoDulceDTO>()
                .ForMember(dulceDTO => dulceDTO.MarcaDeDulce, opciones => opciones.MapFrom(MapInfoDulceDTODulces));
            CreateMap<SaboresCreacionDTO, Sabor>();
            CreateMap<Sabor, SaborDTO>();
            
        }

        private List<InfoDulceDTO> MapInfoDulceDTODulces(Dulces dulce, InfoDulceDTO infoDulceDTO)
        {
            var resultado = new List<InfoDulceDTO>();

            if (dulce.DulceInfos == null) { return resultado; }

            foreach (var dulceInfo in dulce.DulceInfos)
            {
                resultado.Add(new InfoDulceDTO()
                {
                    Id = dulceInfo.DulceId,
                    MarcaDeDulce = dulceInfo.InformacionDulce.MarcaDeDulce
                });
            }

            return resultado;
        }

        private List<DulceInfo> MapDulcesInfo(InfoDulceCreacionDTO infoDulceCreacionDTO, Dulces dulces)
        {
            var resultado = new List<DulceInfo>();

            if(infoDulceCreacionDTO.MarcaId == null) { return resultado; }

            foreach (var dulceId in infoDulceCreacionDTO.MarcaId)
            {
                resultado.Add(new DulceInfo() { DulceId = dulceId });
            }

            return resultado;
        }
    }
}
