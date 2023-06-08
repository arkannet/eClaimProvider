using System;

namespace eClaimProvider.Application.Features.Invoice_Details.Queries.GetAll
{
    public class GetAllInvoice_DetailResponse
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public string ServiceId { get; set; }
        public string Service_Name { get; set; }
        public string DrName { get; set; }
        public decimal Price { get; set; }
        public int Isurance_Ratio { get; set; }
        public DateTime ServiceDate { get; set; }
        public decimal Co_Cash { get; set; }
        public decimal P_Cash { get; set; }
        public int Qty { get; set; }
        public string Comment { get; set; }
        public bool IsExamination { get; set; }
    }
}