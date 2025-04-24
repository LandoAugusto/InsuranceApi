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
            CreateMap<AddressTypeModel, AddressType>().ReverseMap();
            CreateMap<DocumentTypeModel, DocumentType>().ReverseMap();
            CreateMap<InsuredTypeModel, InsuredType>().ReverseMap();
        }
    }
}
