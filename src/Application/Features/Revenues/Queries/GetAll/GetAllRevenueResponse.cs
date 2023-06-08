using System;

namespace eClaimProvider.Application.Features.Revenues.Queries.GetAll
{
    public class GetAllRevenueResponse
    {
        public int CompanyId { get; set; }
        public string Comment { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}