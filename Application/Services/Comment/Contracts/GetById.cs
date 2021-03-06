using System;
using SL2021.Application.Services.Contracts;

namespace SL2021.Application.Services.Comment.Contracts
{
    public static class GetById
    {
        public sealed class Request
        {
            public int Id { get; set; }
        }

        public sealed class Response
        {
            public int? Id { get; set; }
            public string Body { get; set; }
            public OwnerResponse Owner { get; set; }
            public string CreatedAt { get; set; }
            public bool IsDeleted { get; set; }
            public int ContentId { get; set; }
            public int? ParentCommentId { get; set; }
        }
    }
}