using System.ComponentModel;

namespace InsuranceApi.Core.Entities.Enumerators
{
    public  enum InsuredTypeEnum
    {
        [Description("Reclamante")]
        Reclamante = 1,

        [Description("Tribunal")]
        Tribunal = 2,

        [Description("Vara")]
        Vara = 2,
    }
}
