using System;

namespace eClaimProvider.Application.Features.Comments.Queries.GetById
{
    public class GetCommentByIdResponse
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string CommentDetails { get; set; }
    }
}