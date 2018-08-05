using AutoMapper;
using Sample.API.ViewModels;
using Scheduler.Model;
using System.Collections.Generic;

namespace Scheduler.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
        Mapper.CreateMap<ContactViewModel, Contact>();

            Mapper.CreateMap<ContactViewModel, Contact>();
        }
    }
}
