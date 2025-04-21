using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Core.Infrastructure.Mapper
{
    public class ConfigurarationMapping : AutoMapper.Profile
    {
        public ConfigurarationMapping()
        {
            CreateMap<QuotationModel, Quotation>().ReverseMap();
          
        }
    }
}
