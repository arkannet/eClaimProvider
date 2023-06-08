using System;

namespace eClaimProvider.Application.Features.REJECTEDs.Queries.GetById
{
    public class GetREJECTEDByIdResponse
    {
        public int Id { get; set; }
        public int Invoice_DetailId { get; set; }
        public string Comment { get; set; }
    }
}