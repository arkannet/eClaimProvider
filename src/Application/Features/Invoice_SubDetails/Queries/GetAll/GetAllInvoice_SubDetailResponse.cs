using System;

namespace eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetAll
{
    public class GetAllInvoice_SubDetailResponse
    {
        public int Id { get; set; }
        public int DetailId { get; set; }
        public string Comment { get; set; }
    }
}