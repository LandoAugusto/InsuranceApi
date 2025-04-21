using System.ComponentModel;

namespace InsuranceApi.Core.Entities.Enumerators
{
    public enum RecordStatusEnum
    {
        [Description("Ativo")]
        Ativo = 1,

        [Description("Inativo")]
        Inativo = 2,
    }
}
