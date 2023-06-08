using System;

namespace eClaimProvider.Application.Features.Companies.Queries.GetById
{
    public class GetCompanyByIdResponse
    {
        public int Id { get; set; }
        public string Company_name { get; set; }
        public string work_type { get; set; }
        public string address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string WEB_site { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Contact_name { get; set; }//
        public string Contact_phone { get; set; }
        public string Contact_titel { get; set; }
        public Boolean Active { get; set; }
        public int CompanyId { get; set; }
        public string UserId { get; set; }
    }
}