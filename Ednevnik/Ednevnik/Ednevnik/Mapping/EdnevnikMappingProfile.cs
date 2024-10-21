using Ednevnik.Models;
using Ednevnik.Models.DTO;
using AutoMapper;

namespace Ednevnik.Mapping
{
    public class EdnevnikMappingProfile : Profile
    {
        public EdnevnikMappingProfile()
        {
            CreateMap<Predmet, PredmetDTORead>();
            CreateMap<PredmetDTOInsertUpdate, Predmet>();

            
        }
    }
}
