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
    public class ServiceRepository : IServiceRepository
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly IRepositoryAsync<Service, string> _repository;

        public ServiceRepository(IRepositoryAsync<Service
            , string> repository , Microsoft.Extensions.Configuration.IConfiguration _configuration)
        {
            configuration = _configuration;
            _repository = repository;
        }
        public async Task<List<Service>> GetAllAsync()
        {
            var sql = "SELECT * FROM Service";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Service>(sql);
                return result.ToList();
            }
        }
        public async Task<Service> GetByIdAsync(string id)
        {
            var sql = "SELECT * FROM Services WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Service>(sql, new { Id = id });
                return result;
            }
        }

        public Task<Service> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}//ICulture_ABRepository