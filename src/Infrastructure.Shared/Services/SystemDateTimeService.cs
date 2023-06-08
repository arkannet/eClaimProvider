using eClaimProvider.Application.Interfaces.Services;
using System;

namespace eClaimProvider.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}