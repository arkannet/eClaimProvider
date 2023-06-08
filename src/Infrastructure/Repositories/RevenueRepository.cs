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
    public class RevenueRepository : IRevenueRepository
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly IRepositoryAsync<Revenue, int> _repository;

        public RevenueRepository(IRepositoryAsync<Revenue
            , int> repository , Microsoft.Extensions.Configuration.IConfiguration _configuration)
        {
            configuration = _configuration;
            _repository = repository;
        }
        public async Task<List<Revenue>> GetAllAsync()
        {
            var sql = "SELECT * FROM Revenues";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Revenue>(sql);
                return result.ToList();
            }
        }
        public async Task<Revenue> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Revenues WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Revenue>(sql, new { Id = id });
                return result;
            }
        }

        public Task<Revenue> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}//ICulture_ABRepository