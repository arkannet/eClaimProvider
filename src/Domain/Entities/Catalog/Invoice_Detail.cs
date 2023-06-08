using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using eClaimProvider.Domain.Contracts;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class Invoice_Detail : AuditableEntity<int>
    {
        //[Key]
        //public int CompanyId { get; set; }
        public string InvoiceId { get; set; }
        public string ServiceId { get; set; }
        public string Service_Name { get; set; }
        public string DrName { get; set; }
        public decimal Price { get; set; }
        public int Isurance_Ratio { get; set; }
        public DateTime ServiceDate { get; set; }
        public decimal Co_Cash { get; set; }
        public decimal P_Cash { get; set; }
        public int Qty { get; set; }
        public string Comment { get; set; }
        public bool IsExamination { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Service Service { get; set; }
    }
}