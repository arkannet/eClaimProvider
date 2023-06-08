using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading;
using eClaimProvider.Domain.Contracts;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class InvoiceComment : AuditableEntity<int>
    {
        
        public int InvoiceId { get; set; }
        public string Comment { get; set; }
        public bool Seen { get; set; }
        public bool Deleted { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}