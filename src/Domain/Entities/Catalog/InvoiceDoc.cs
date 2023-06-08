using eClaimProvider.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class InvoiceDoc : AuditableEntity<int>
    {
        public string DocTitle { get; set; }
        public string Doc { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
