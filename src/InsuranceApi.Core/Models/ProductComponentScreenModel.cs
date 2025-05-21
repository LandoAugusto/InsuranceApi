namespace InsuranceApi.Core.Models
{
    public class ProductComponentScreenModel
    {
        public ProductComponentModel Product { get; set; }
        public List<ComponentModel> Component { get; set; } = [];
    }
}
