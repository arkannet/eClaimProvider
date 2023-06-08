using System;

namespace eClaimProvider.Application.Features.Services.Queries.GetById
{
    public class GetServiceByIdResponse
    {
        public string Id { get; set; }
        public int services_categoryId { get; set; }

        public string Service_Name { get; set; }

        public decimal Price { get; set; }
        public int DurationTime { get; set; }
        public Boolean Descounted { get; set; }
        public int Descount_Ratio { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public bool IsRatio { get; set; }
        public decimal finance_Value { get; set; }
        public bool Deleted { get; set; }
        public bool IsKit { get; set; }
        public int Classified { get; set; }
        public bool ISoperation { get; set; }
        public bool WithRes { get; set; }
        public bool IsExamination { get; set; }
        public bool Isinertnal { get; set; }
        public decimal Price1 { get; set; }
        public string More_Details { get; set; }
        public bool CP { get; set; }
        public string Services_NameAR { get; set; }
        public bool Isdevice { get; set; }
        public bool Fees { get; set; }

    }
}