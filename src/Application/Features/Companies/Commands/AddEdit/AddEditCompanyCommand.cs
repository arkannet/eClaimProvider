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
using eClaimProvider;
using eClaimProvider.Application.Interfaces.Services;
using eClaimProvider.Application.Requests;
using System;

namespace eClaimProvider.Application.Features.Companies.Commands.AddEdit
{
    public partial class AddEditCompanyCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Company_name { get; set; }
        public string work_type { get; set; }
        public string address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string WEB_site { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Contact_name { get; set; }//
        public string Contact_phone { get; set; }
        public string Contact_titel { get; set; }
        public Boolean Active { get; set; }
        public int CompanyId { get; set; }
        public string UserId { get; set; }
        //public UploadRequest UploadRequest { get; set; }

    }

    internal class AddEditCompanyCommandHandler : IRequestHandler<AddEditCompanyCommand, Result<int>>
    {
        //private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditCompanyCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditCompanyCommandHandler(IUnitOfWork<int> unitOfWork, IUploadService uploadService, IMapper mapper, IStringLocalizer<AddEditCompanyCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditCompanyCommand command, CancellationToken cancellationToken)
        {
            //var uploadRequest = command.UploadRequest;
            if (command.Id == 0)
            {
                var claim = _mapper.Map<Company>(command);
                await _unitOfWork.Repository<Company>().AddAsync(claim);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCompanyCacheKey);
                return await Result<int>.SuccessAsync(claim.Id, _localizer["Company Saved"]);
            }
            else
            {
                var claim = await _unitOfWork.Repository<Company>().GetByIdAsync(command.Id);
                if (claim != null)
                {


                    claim.Company_name = command.Company_name ?? claim.Company_name;
                    claim.work_type = command.work_type ?? claim.work_type;

                    claim.address = command.address ?? claim.address;
                    claim.Phone1 = command.Phone1 ?? claim.Phone1;
                    claim.Phone2 = command.Phone2 ?? claim.Phone2;

                    claim.WEB_site = command.WEB_site ?? claim.WEB_site;
                    claim.Email1 = command.Email1 ?? claim.Email1;
                    claim.Email2 = command.Email2 ?? claim.Email2;
                    claim.Contact_name = command.Contact_name ?? claim.Contact_name;
                    claim.Contact_titel = command.Contact_titel ?? claim.Contact_titel;

                    claim.UserId = command.UserId ?? claim.UserId;
                    claim.Contact_phone = command.Contact_phone ?? claim.Contact_phone;
                    claim.Active = command.Active;
                    claim.CompanyId = command.CompanyId;
                   
                   
  

                    await _unitOfWork.Repository<Company>().UpdateAsync(claim);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCompanyCacheKey);
                    return await Result<int>.SuccessAsync(claim.Id, _localizer["Company Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Company Not Found!"]);
                }
            }
        }
    }
}