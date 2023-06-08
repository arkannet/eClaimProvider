using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using eClaimProvider.Domain.Contracts;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class Result : AuditableEntity<int>
    {
        //[Key]
        //public int CompanyId { get; set; }
        public int DetailId { get; set; }
        public string ResultDetails { get; set; }

        public string ServiceId { get; set; }

    }
}