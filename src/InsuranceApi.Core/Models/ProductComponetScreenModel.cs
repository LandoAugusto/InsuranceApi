using InsuranceApi.Core.Entities;

namespace InsuranceApi.Core.Models
{
    public class ProductComponetScreenModel
    {
        public ProductComponentModel Product { get; set; }

        public List<ComponentModel> Component { get; set; } = [];
    }
}
