using eClaimProvider.Domain.Contracts;
using eClaimProvider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class TimeLine : AuditableEntity<int>
    {
        public string ClaimId { get; set; }
        public ClaimAttribute Status { get; set; }
        public DateTime? AtDate { get; set; }

        public virtual Claim Claim { get; set; }
    }
}
