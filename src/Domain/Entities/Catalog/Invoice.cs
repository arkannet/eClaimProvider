using eClaimProvider.Domain.Contracts;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class Invoice : AuditableEntity<string>
    {
        public int PolicyId { get; set; }
        public string PatientId { get; set; }
        public int ContractId { get; set; }
        public int CompanyId { get; set; }
        public int Stat { get; set; }
        public DateTime DoneDate { get; set; }
        public bool Moved { get; set; }
        public DateTime Movedon { get; set; }
        public string Isrealted { get; set; }
        public int suspended { get; set; }
        public bool Cards{ get; set; }
        public string Policy_Insu_no { get; set; }
        public virtual Policy Policy { get; set; }


    }
}