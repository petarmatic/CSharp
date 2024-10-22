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


            CreateMap<Obavijest, ObavijestDTORead>().ForCtorParam(
                   "PredmetNaziv",
                   opt => opt.MapFrom(src => src.Predmet.Naziv)
               );


        }
    }
}
