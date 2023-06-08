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
    public class Invoice_DetailRepository : IInvoice_DetailRepository
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly IRepositoryAsync<Invoice_Detail, int> _repository;

        public Invoice_DetailRepository(IRepositoryAsync<Invoice_Detail
            , int> repository , Microsoft.Extensions.Configuration.IConfiguration _configuration)
        {
            configuration = _configuration;
            _repository = repository;
        }
        public async Task<List<Invoice_Detail>> GetAllAsync()
        {
            var sql = "SELECT * FROM Invoice_Details";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Invoice_Detail>(sql);
                return result.ToList();
            }
        }
        public async Task<Invoice_Detail> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Invoice_Details WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Invoice_Detail>(sql, new { Id = id });
                return result;
            }
        }

        public Task<Invoice_Detail> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}//ICulture_ABRepository