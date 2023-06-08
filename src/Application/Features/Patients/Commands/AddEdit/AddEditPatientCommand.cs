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

namespace eClaimProvider.Application.Features.Patients.Commands.AddEdit
{
    public partial class AddEditPatientCommand : IRequest<Result<string >>
    {


        
        public string Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string First_Name_Arb { get; set; }
        public string Last_Name_Arb { get; set; }
        public string Nationalty { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string FID { get; set; }
        public string address { get; set; }
        public string mobile1 { get; set; }
        public string mobile2 { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public Boolean? Active { get; set; }
        public Boolean? Deleted { get; set; }
        public string InsuranceCard { get; set; }


        //public UploadRequest UploadRequest { get; set; }

    }

    internal class AddEditPatientCommandHandler : IRequestHandler<AddEditPatientCommand, Result<string >>
    {
        //private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditPatientCommandHandler> _localizer;
        private readonly IUnitOfWork<string > _unitOfWork;

        public AddEditPatientCommandHandler(IUnitOfWork<string> unitOfWork, IUploadService uploadService, IMapper mapper, IStringLocalizer<AddEditPatientCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<string >> Handle(AddEditPatientCommand command, CancellationToken cancellationToken)
        {
            //var uploadRequest = command.UploadRequest;
            //if (command.Id == null)
            //{

            //}
            //else
            {
                var invoice = await _unitOfWork.Repository<Patient>().GetByIdAsync(command.Id);
                if (invoice != null)
                {


                    invoice.First_Name = command.First_Name ?? invoice.First_Name;

                    invoice.Last_Name = command.Last_Name ?? invoice.Last_Name;

                    invoice.First_Name_Arb = command.First_Name_Arb ?? invoice.First_Name_Arb;
                    invoice.Last_Name_Arb = command.Last_Name_Arb ?? invoice.Last_Name_Arb;
                    invoice.Nationalty = command.Nationalty ?? invoice.Nationalty;

                    invoice.Gender = command.Gender ?? invoice.Gender;
                    invoice.FID = command.FID ?? invoice.FID;
                    invoice.address = command.address ?? invoice.address;
                    invoice.mobile1 = command.mobile1 ?? invoice.mobile1;
                    invoice.mobile2 = command.mobile2 ?? invoice.mobile2;
                    invoice.Email = command.Email ?? invoice.Email;
                    invoice.Picture = command.Picture ?? invoice.Picture;

                    invoice.Deleted = command.Deleted;
                    invoice.Active = command.Active;
                    invoice.InsuranceCard = command.InsuranceCard ?? invoice.InsuranceCard;

                    await _unitOfWork.Repository<Patient>().UpdateAsync(invoice);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllPatientCacheKey);
                    return await Result<string>.SuccessAsync(invoice.Id, _localizer["Patient Updated"]);
                }
                else
                {
                    var invoice1 = _mapper.Map<Patient>(command);
                    await _unitOfWork.Repository<Patient>().AddAsync(invoice1);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllPatientCacheKey);
                    return await Result<string>.SuccessAsync(invoice1.Id, _localizer["Patient Saved"]);
                }
            }
        }
    }
}// ?? patient.CategoryName;