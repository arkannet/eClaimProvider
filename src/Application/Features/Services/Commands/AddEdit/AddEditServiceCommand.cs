using System.ComponentModel.DataAnnotations;
using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;
using System;
using eClaimProvider.Application.Interfaces.Services;
using eClaimProvider.Application.Requests;

namespace eClaimProvider.Application.Features.Services.Commands.AddEdit
{
    public partial class AddEditServiceCommand : IRequest<Result<string >>
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


        //public UploadRequest UploadRequest { get; set; }

    }

    internal class AddEditServiceCommandHandler : IRequestHandler<AddEditServiceCommand, Result<string >>
    {
        //private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditServiceCommandHandler> _localizer;
        private readonly IUnitOfWork<string > _unitOfWork;

        public AddEditServiceCommandHandler(IUnitOfWork<string> unitOfWork, IUploadService uploadService, IMapper mapper, IStringLocalizer<AddEditServiceCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<string >> Handle(AddEditServiceCommand command, CancellationToken cancellationToken)
        {
            //var uploadRequest = command.UploadRequest;
            //if (command.Id == null)
            //{

            //}
            //else
            {
                var invoice = await _unitOfWork.Repository<Service>().GetByIdAsync(command.Id);
                if (invoice != null)
                {

                    invoice.services_categoryId = command.services_categoryId;
                    invoice.Service_Name = command.Service_Name ?? invoice.Service_Name;
                    invoice.Price = command.Price;
                    invoice.DurationTime = command.DurationTime;
                    invoice.Descounted = command.Descounted;

                    invoice.Descount_Ratio = command.Descount_Ratio;
                    invoice.StartDate = command.StartDate;
                    invoice.EndDate = command.EndDate;
                    invoice.Active = command.Active;
                    invoice.IsRatio = command.IsRatio;
                    invoice.finance_Value = command.finance_Value;
                    invoice.Deleted = command.Deleted;
                    invoice.IsKit = command.IsKit;
                    invoice.Classified = command.Classified;
                    invoice.ISoperation = command.ISoperation;
                    invoice.WithRes = command.WithRes;
                    invoice.IsExamination = command.IsExamination;
                    invoice.Isinertnal = command.Isinertnal;
                    invoice.Price1 = command.Price1;
                    invoice.More_Details = command.More_Details ?? invoice.More_Details;
                    invoice.CP = command.CP;
                    invoice.Services_NameAR = command.Services_NameAR ?? invoice.Services_NameAR;
                    invoice.Isdevice = command.Isdevice;
                    invoice.Fees = command.Fees;
                    await _unitOfWork.Repository<Service>().UpdateAsync(invoice);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllServiceCacheKey);
                    return await Result<string>.SuccessAsync(invoice.Id, _localizer["Service Updated"]);
                }
                else
                {
                    var invoice1 = _mapper.Map<Service>(command);
                    await _unitOfWork.Repository<Service>().AddAsync(invoice1);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllServiceCacheKey);
                    return await Result<string>.SuccessAsync(invoice1.Id, _localizer["Service Saved"]);
                }
            }
        }
    }
}// ?? patient.CategoryName;