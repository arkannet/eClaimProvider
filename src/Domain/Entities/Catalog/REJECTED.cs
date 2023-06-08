using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using eClaimProvider.Domain.Contracts;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class REJECTED : AuditableEntity<int>
    {
        //[Key]
        //public int CompanyId { get; set; }
        public int Invoice_DetailId { get; set; }
        public string Comment { get; set; }

    }
}