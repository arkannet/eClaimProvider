using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using eClaimProvider.Domain.Contracts;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class Invoice_SubDetail : AuditableEntity<int>
    {
        //[Key]
        //public int CompanyId { get; set; }
        public int DetailId { get; set; }
        public string Comment { get; set; }
        public virtual Invoice_Detail Invoice_Detail { get; set; }

    }
}