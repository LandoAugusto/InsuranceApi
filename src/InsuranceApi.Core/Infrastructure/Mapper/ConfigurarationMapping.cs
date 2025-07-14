using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Core.Infrastructure.Mapper
{
    public class ConfigurarationMapping : AutoMapper.Profile
    {
        public ConfigurarationMapping()
        {
            CreateMap<DocumentTypeModel, DocumentType>().ReverseMap();
            CreateMap<PersonModel, Person>().ReverseMap();
            CreateMap<AddressModel, Address>().ReverseMap();            
            CreateMap<FlexRateModel, FlexRate>().ReverseMap();
            CreateMap<FlexRateModel, FlexRate>().ReverseMap();
            CreateMap<QuotationModel, Quotation>().ReverseMap();
            CreateMap<ProductComponentModel, ProductComponent>().ReverseMap();
            CreateMap<ComponentModel, Core.Entities.Component>().ReverseMap();
            CreateMap<ProductComponetScreenModel, ProductComponentScreen>().ReverseMap();
            CreateMap<CivilCourtModel, CivilCourt>().ReverseMap();
            CreateMap<CivilCourtLaborCourtModel, LaborCourt>().ReverseMap();
            CreateMap<LaborCourtModel, LaborCourt>().ReverseMap();
            CreateMap<LegalRecourseTypeModel, LegalRecourseType>()
            .ForMember(dest => dest.LegalRecourseTypeId, m => m.MapFrom(a => a.LegalRecourseTypeId))
            .ForMember(dest => dest.Name, m => m.MapFrom(a => a.Name))
            .ForMember(dest => dest.Status, m => m.MapFrom(a => a.Status)).ReverseMap();
        }
    }
}
