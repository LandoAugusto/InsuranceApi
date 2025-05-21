namespace InsuranceApi.Core.Models
{
    public class InsuredObjectBlockModel
    {
        public int InsuredObjectBlockId { get; set; }
        public int InsuredObjectId { get; set; }
        public int PrintMode { get; set; }
        public string Contents { get; set; }
        public bool StartInNewLine { get; set; }
        public int PrintOrder { get; set; }
    }
}
