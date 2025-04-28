using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Core.Infrastructure.Mapper
{
    public class ConfigurarationMapping : AutoMapper.Profile
    {
        public ConfigurarationMapping()
        {
            CreateMap<FlexRateModel, FlexRate>().ReverseMap();
            CreateMap<QuotationModel, Quotation>().ReverseMap();
            CreateMap<QuotationModel, Quotation>().ReverseMap();
            CreateMap<ProductComponentModel, ProductComponent>().ReverseMap();
            CreateMap<ComponentModel, Core.Entities.Component>().ReverseMap();
            CreateMap<ProductComponetScreenModel, ProductComponentScreen>().ReverseMap();
        }
    }
}
