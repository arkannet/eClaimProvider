using eClaimProvider.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class Provider : AuditableEntity<int>
    {
        public string Provider_name { get; set; }
        public string address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
