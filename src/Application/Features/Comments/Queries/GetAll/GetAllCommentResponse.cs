using System;

namespace eClaimProvider.Application.Features.Comments.Queries.GetAll
{
    public class GetAllCommentResponse
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string CommentDetails { get; set; }
    }
}
