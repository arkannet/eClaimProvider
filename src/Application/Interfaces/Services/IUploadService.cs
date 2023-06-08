using eClaimProvider.Application.Requests;

namespace eClaimProvider.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}