using System;
using System.Collections.Generic;
using UntitledTechie.Infrastructure.Entities;

namespace UntitledTechie.Service.Contract
{
    public interface IPostService
    {
        IEnumerable<PostEntity> GetPostsByAccountId(Guid accountId);
        IEnumerable<PostEntity> GetLikedPostsByAccountId(Guid accountId);
        IEnumerable<PostEntity> GetBookmarkedPostsByAccountId(Guid accountId);
        IEnumerable<CommentEntity> GetAllComments(Guid postId);
        IEnumerable<CommentEntity> GetAllSubComments(Guid postId, Guid commentId);
    }
}