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
            CreateMap<ObavijestDTOInsertUpdate, Obavijest>();
            CreateMap<Ocjena,OcjenaDTORead>();
            CreateMap<OcjenaDTOInsertUpdate, Ocjena>();

            CreateMap<Obavijest, ObavijestDTORead>().ForCtorParam(
                   "PredmetNaziv",
                   opt => opt.MapFrom(src => src.Predmet.Naziv)
               );


            CreateMap<Ocjena, OcjenaDTORead>().ForCtorParam(
                "PredmetNaziv",
                opt => opt.MapFrom(src => src.Predmet.Naziv)
                );


        }
    }
}
