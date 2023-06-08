using eClaimProvider.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Application.Interfaces.Common;
using eClaimProvider.Shared.Wrapper;
using System.Windows.Input;

namespace eClaimProvider.Application.Interfaces.Repositories
{
    public interface IDapperUnitOfWork : IDisposable
    {

        //  ISafeRepository Safes { get; }
        //IClaimRepository Claims { get; }
        IInvoiceRepository Invoices { get; }
        IResultRepository Results { get; }
        IRevenueRepository Revenues { get; }
        IPatientRepository Patients { get; }
        IREJECTEDRepository REJECTEDs { get; }
        IServiceRepository Services { get; }
        IInvoice_DetailRepository Invoice_Details { get; }
        ICommentRepository Comments { get; }
        IInvoice_SubDetailRepository Invoice_SubDetails { get; }
        ICompanyRepository Companies {get; }

        Task<int> Commit(CancellationToken cancellationToken);

        Task<int> CommitAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
        //Claim_Form
        Task Rollback();

    }
}
