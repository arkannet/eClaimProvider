using eClaimProvider.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class PriceList : AuditableEntity<int>
    {
        public string Ref { get; set; }
        public decimal Price { get; set; }
        public bool PriceIsEditable { get; set; }
        public decimal limitation { get; set; }

        public bool IsBlocked { get; set; }
         
        public virtual Policy Policy { get; set; }
        public virtual Service Service { get; set; }

    }
}
