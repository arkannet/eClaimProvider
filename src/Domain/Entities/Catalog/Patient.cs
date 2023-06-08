using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eClaimProvider.Domain.Contracts;

namespace eClaimProvider.Domain.Entities.Catalog
{
    public class Patient : AuditableEntity<string>
    {
       
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string First_Name_Arb { get; set; }
        public string Last_Name_Arb { get; set; }
        public string Nationalty { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string FID { get; set; }
        public string address { get; set; }
        public string mobile1 { get; set; }
        public string mobile2 { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public Boolean? Active { get; set; }
        public Boolean? Deleted { get; set; }
        public string InsuranceCard { get; set; }

       // 
    }
}
