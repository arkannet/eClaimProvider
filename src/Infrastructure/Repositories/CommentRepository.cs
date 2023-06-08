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
    public class CommentRepository : ICommentRepository
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        private readonly IRepositoryAsync<InvoiceComment, int> _repository;

        public CommentRepository(IRepositoryAsync<InvoiceComment
            , int> repository , Microsoft.Extensions.Configuration.IConfiguration _configuration)
        {
            configuration = _configuration;
            _repository = repository;
        }
        public async Task<List<InvoiceComment>> GetAllAsync()
        {
            var sql = "SELECT * FROM Comments";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<InvoiceComment>(sql);
                return result.ToList();
            }
        }
        public async Task<InvoiceComment> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Comments WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<InvoiceComment>(sql, new { Id = id });
                return result;
            }
        }

        public Task<InvoiceComment> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}//ICulture_ABRepository