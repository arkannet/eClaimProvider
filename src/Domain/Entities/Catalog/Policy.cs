using eClaimProvider.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class Policy : AuditableEntity<int>
    {
        public string Ref { get; set; }
        public decimal Flimit { get; set; }
        public decimal Mlimit { get; set; }
        public DateTime? ValedDate { get; set; }
        public bool Active { get; set; }
        public virtual Company Company { get; set; }


    }
}
