using System;

namespace eClaimProvider.Application.Features.Revenues.Queries.GetById
{
    public class GetRevenueByIdResponse
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Comment { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}