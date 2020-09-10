using AutoMapper;

using AutoDock.Catalog.Domain.Core;
using AutoDock.Catalog.Business.Interfaces.DTO;

namespace AutoDock.Catalog.Business.Implementation.Mapping
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Model, ReadModelDto>()
                .ForMember(dto => dto.Id, conf => conf.MapFrom(model => model.Id))
                .ForMember(dto => dto.Name, conf => conf.MapFrom(model => model.Name))
                .ForMember(dto => dto.ProductionStart, conf => conf.MapFrom(model => model.ProductionStart))
                .ForMember(dto => dto.ProductionEnd, conf => conf.MapFrom(model => model.ProductionEnd));
        }
    }
}
