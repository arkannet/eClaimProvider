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
    public class PatientRepository : IPatientRepository
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly IRepositoryAsync<Patient, string> _repository;

        public PatientRepository(IRepositoryAsync<Patient
            , string> repository , Microsoft.Extensions.Configuration.IConfiguration _configuration)
        {
            configuration = _configuration;
            _repository = repository;
        }
        public async Task<List<Patient>> GetAllAsync()
        {
            var sql = "SELECT * FROM Patients";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Patient>(sql);
                return result.ToList();
            }
        }
        public async Task<Patient> GetByIdAsync(string id)
        {
            var sql = "SELECT * FROM Patients WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Patient>(sql, new { Id = id });
                return result;
            }
        }

        public Task<Patient> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}//ICulture_ABRepository