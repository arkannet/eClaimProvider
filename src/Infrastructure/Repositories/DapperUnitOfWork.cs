using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using LazyCache;
using System.Collections;
using eClaimProvider.Application.Interfaces.Services;
using eClaimProvider.Infrastructure.Contexts;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using System.Security.Policy;
using static AutoMapper.Internal.ExpressionFactory;
using System.Xml.Linq;

namespace Dapper.Infrastructure.Repositories
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly BlazorHeroContext _dbContext;
        private bool disposed;
        private Hashtable _repositories;
        private readonly IAppCache _cache;
        public DapperUnitOfWork(IRevenueRepository rev,IResultRepository res,IREJECTEDRepository REJ,IInvoice_DetailRepository invodet, IServiceRepository serv,ICommentRepository comme,IInvoice_SubDetailRepository invosubde,ICompanyRepository comp,IPatientRepository patients, IInvoiceRepository invoices,BlazorHeroContext dbContext, ICurrentUserService currentUserService, IAppCache cache)

            
        {
            Revenues = rev;
            Results = res;
            REJECTEDs = REJ;
            Services = serv;
            Invoice_Details = invodet;
            Comments = comme;
            Invoice_SubDetails = invosubde;
            Companies = comp;
            Patients = patients;
            Invoices = invoices;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _currentUserService = currentUserService;
            _cache = cache;

        }
        public IInvoice_SubDetailRepository Invoice_SubDetails { get; }
        public IInvoice_DetailRepository Invoice_Details { get; }
        public IResultRepository Results { get; }
        public IREJECTEDRepository REJECTEDs { get; }
        public IRevenueRepository Revenues { get; }
        public IInvoiceRepository Invoices { get; }
        public ICompanyRepository Companies { get; }
        public ICommentRepository Comments { get; }
        public IServiceRepository Services { get; }
        public IPatientRepository Patients { get; }
        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CommitAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            foreach (var cacheKey in cacheKeys)
            {
                _cache.Remove(cacheKey);
            }
            return result;
        }

        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
    }
}
