using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using eClaimProvider.Domain.Contracts;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class Revenue : AuditableEntity<int>
    {
       
        public int CompanyId { get; set; }
        public string Comment { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}