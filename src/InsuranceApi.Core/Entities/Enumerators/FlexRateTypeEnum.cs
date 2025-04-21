using System.ComponentModel;

namespace InsuranceApi.Core.Entities.Enumerators
{
    public enum FlexRateTypeEnum
    {
        [Description("Sobre a taxa")]
        Tax = 1,

        [Description("Sobre o prêmio")]
        Premium = 2,


        [Description("Sobre a comissão")]
        Comission = 3,

    }
}
