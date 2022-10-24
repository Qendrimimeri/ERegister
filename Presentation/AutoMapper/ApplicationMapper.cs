using Application.ViewModels;
using AutoMapper;
using Domain.Data.Entities;

namespace Presentation.AutoMapper
{
    public class ApplicationMapper :Profile
    {
        public ApplicationMapper()
        {
            CreateMap<PollCenter, PollCenterVM>().ReverseMap();
            CreateMap<Kqzregister, KqzRegisterVM>().ReverseMap();
            CreateMap<Village, AddVillageVM>().ForMember(dest => dest.VillageName, opt => opt.MapFrom(src => src.Name)).ReverseMap();
            CreateMap<Neighborhood, AddNeighborhoodVM>().ForMember(dest => dest.NeighborhoodName, opt => opt.MapFrom(src => src.Name)).ReverseMap();
            //CreateMap<Neighborhood, AddNeighborhoodVM>().ForMember(dest => dest.VillageId, opt => opt.Ignore());

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Neighborhood, AddNeighborhoodVM>()
                    //Ignoring the Address property of the destination type
                    .ForMember(dest => dest.VillageId, act => act.Ignore());
            });

            CreateMap<Block, AddBlockVM>().ForMember(dest => dest.BlockName, opt => opt.MapFrom(src => src.Name)).ReverseMap();

            CreateMap<Street, AddStreetVM>().ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Name)).ReverseMap();


        }
    }
}
