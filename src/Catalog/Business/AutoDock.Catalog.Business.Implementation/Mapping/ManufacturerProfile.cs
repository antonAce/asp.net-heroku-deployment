using AutoMapper;

using AutoDock.Catalog.Domain.Core;
using AutoDock.Catalog.Business.Interfaces.DTO;

namespace AutoDock.Catalog.Business.Implementation.Mapping
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<Manufacturer, ReadManufacturerDto>()
                .ForMember(dto => dto.Id, conf => conf.MapFrom(model => model.Id))
                .ForMember(dto => dto.Name, conf => conf.MapFrom(model => model.Name))
                .ForMember(dto => dto.Foundation, conf => conf.MapFrom(model => model.Foundation));
        }
    }
}