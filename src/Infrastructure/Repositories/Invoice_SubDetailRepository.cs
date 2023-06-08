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
    public class Invoice_SubDetailRepository : IInvoice_SubDetailRepository
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly IRepositoryAsync<Invoice_SubDetail, int> _repository;

        public Invoice_SubDetailRepository(IRepositoryAsync<Invoice_SubDetail
            , int> repository , Microsoft.Extensions.Configuration.IConfiguration _configuration)
        {
            configuration = _configuration;
            _repository = repository;
        }
        public async Task<List<Invoice_SubDetail>> GetAllAsync()
        {
            var sql = "SELECT * FROM Invoice_SubDetails";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Invoice_SubDetail>(sql);
                return result.ToList();
            }
        }
        public async Task<Invoice_SubDetail> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Invoice_SubDetails WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Invoice_SubDetail>(sql, new { Id = id });
                return result;
            }
        }

        public Task<Invoice_SubDetail> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}//ICulture_ABRepository