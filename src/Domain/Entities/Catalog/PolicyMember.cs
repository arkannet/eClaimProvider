using eClaimProvider.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class PolicyMember : AuditableEntity<int>
    {
        public decimal limit { get; set; }

        public bool Active { get; set; }
        public bool IsBlocked { get; set; }
        public string CardNo { get; set; }
        public string CardImage { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
