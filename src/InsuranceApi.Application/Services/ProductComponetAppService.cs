using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class ProductComponetAppService(IMapper mapper, IProductComponetRepository productComponetRepository) : IProductComponetAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IProductComponetRepository _productComponetRepository = productComponetRepository;

        public async Task<ProductComponetScreenModel?> ListAsync(int code)
        {
            var entidade = await _productComponetRepository.GetAsync(code);
            if (entidade == null) return null;
            var response = new ProductComponetScreenModel()
            {
                Product = _mapper.Map<ProductComponentModel>(entidade)
            };

            foreach (var item in entidade.ProductComponentScreen)
            {
                var configurationComponentModel = _mapper.Map<ComponentModel>(item.Component);
                configurationComponentModel.Order = item.Order;
                response.Component.Add(configurationComponentModel);
            }

            return response;
        }
    }
}
