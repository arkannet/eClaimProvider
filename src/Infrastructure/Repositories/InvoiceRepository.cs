using Dapper;
using eClaimProvider.Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using AutoMapper.Configuration;

namespace eClaimProvider.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly IRepositoryAsync<Invoice, string> _repository;

        public InvoiceRepository(IRepositoryAsync<Invoice
            , string> repository , Microsoft.Extensions.Configuration.IConfiguration _configuration)
        {
            configuration = _configuration;
            _repository = repository;
        }
        public async Task<List<Invoice>> GetAllAsync()
        {
            var sql = "SELECT * FROM Invoices";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Invoice>(sql);
                return result.ToList();
            }
        }
        public async Task<Invoice> GetByIdAsync(string id)
        {
            var sql = "SELECT * FROM Invoices WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Invoice>(sql, new { Id = id });
                return result;
            }
        }

        public Task<Invoice> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}//ICulture_ABRepository