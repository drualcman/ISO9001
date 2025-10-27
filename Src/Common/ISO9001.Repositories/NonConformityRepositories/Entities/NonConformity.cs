﻿namespace ISO9001.Repositories.NonConformityRepositories.Entities
{
    public class NonConformity
    {
        public Guid Id { get; set; }  
        public string EntityId { get; set; }
        public string CompanyId { get; set; }
        public string AffectedProcess { get; set; }
        public string Cause { get; set; }
        public string Status { get; set; }
        public DateTime ReportedAt { get; set; }
        public List<NonConformityDetail> NonConformityDetails { get; set; }

    }
}
