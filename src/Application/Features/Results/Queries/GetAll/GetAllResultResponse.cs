using System;

namespace eClaimProvider.Application.Features.Results.Queries.GetAll
{
    public class GetAllResultResponse
    {
        public int Id { get; set; }
        public int DetailId { get; set; }
        public string ResultDetails { get; set; }

        public string ServiceId { get; set; }
    }
}