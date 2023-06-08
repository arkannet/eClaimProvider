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
    public class REJECTEDRepository : IREJECTEDRepository
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly IRepositoryAsync<REJECTED, int> _repository;

        public REJECTEDRepository(IRepositoryAsync<REJECTED
            , int> repository , Microsoft.Extensions.Configuration.IConfiguration _configuration)
        {
            configuration = _configuration;
            _repository = repository;
        }
        public async Task<List<REJECTED>> GetAllAsync()
        {
            var sql = "SELECT * FROM REJECTEDs";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<REJECTED>(sql);
                return result.ToList();
            }
        }
        public async Task<REJECTED> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM REJECTEDs WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<REJECTED>(sql, new { Id = id });
                return result;
            }
        }

        public Task<REJECTED> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}//ICulture_ABRepository