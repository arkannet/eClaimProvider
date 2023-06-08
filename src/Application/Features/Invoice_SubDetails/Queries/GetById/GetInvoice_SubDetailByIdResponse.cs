using System;

namespace eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetById
{
    public class GetInvoice_SubDetailByIdResponse
    {
        public int Id { get; set; }
        public int DetailId { get; set; }
        public string Comment { get; set; }
    }
}