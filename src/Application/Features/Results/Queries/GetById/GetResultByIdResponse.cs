using System;

namespace eClaimProvider.Application.Features.Results.Queries.GetById
{
    public class GetResultByIdResponse
    {
        public int Id { get; set; }
        public int DetailId { get; set; }
        public string ResultDetails { get; set; }

        public string ServiceId { get; set; }
    }
}