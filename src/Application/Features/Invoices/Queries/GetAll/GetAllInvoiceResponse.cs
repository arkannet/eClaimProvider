using System;

namespace eClaimProvider.Application.Features.Invoices.Queries.GetAll
{
    public class GetAllInvoiceResponse
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public int ContractId { get; set; }
        public int CompanyId { get; set; }
        public int Stat { get; set; }
        public DateTime ServiceDoneDate { get; set; }
        public bool Moved { get; set; }
        public DateTime Movedon { get; set; }
        public string Isrealted { get; set; }
        public int suspended { get; set; }
        public bool Cards { get; set; }
        public string Policy_Insu_no { get; set; }
    }
}