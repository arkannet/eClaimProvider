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

namespace eClaimProvider.Application.Features.Comments.Commands.AddEdit
{
    public partial class AddEditCommentCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Comment { get; set; }
        //public UploadRequest UploadRequest { get; set; }

    }

    internal class AddEditCommentCommandHandler : IRequestHandler<AddEditCommentCommand, Result<int>>
    {
        //private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditCommentCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditCommentCommandHandler(IUnitOfWork<int> unitOfWork, IUploadService uploadService, IMapper mapper, IStringLocalizer<AddEditCommentCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditCommentCommand command, CancellationToken cancellationToken)
        {
            //var uploadRequest = command.UploadRequest;
            if (command.Id == 0)
            {
                var claim = _mapper.Map<InvoiceComment>(command);
                await _unitOfWork.Repository<InvoiceComment>().AddAsync(claim);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCommentCacheKey);
                return await Result<int>.SuccessAsync(claim.Id, _localizer["Comment Saved"]);
            }
            else
            {
                var claim = await _unitOfWork.Repository<InvoiceComment>().GetByIdAsync(command.Id);
                if (claim != null)
                {


                    claim.Comment = command.Comment ?? claim.Comment;
                    claim.InvoiceId = command.InvoiceId;


                   
                   
  

                    await _unitOfWork.Repository<InvoiceComment>().UpdateAsync(claim);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCommentCacheKey);
                    return await Result<int>.SuccessAsync(claim.Id, _localizer["Comment Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Comment Not Found!"]);
                }
            }
        }
    }
}