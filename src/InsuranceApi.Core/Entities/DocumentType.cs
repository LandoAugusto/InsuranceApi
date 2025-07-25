﻿namespace InsuranceApi.Core.Entities
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public required string Name { get; set; }
        public int Status { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime InclusionDate { get; set; }
        public int? LastChangeUserId { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public virtual ICollection<Person> Person { get; set; } = new HashSet<Person>();
    }
}
