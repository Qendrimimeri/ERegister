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

        }
    }
}
