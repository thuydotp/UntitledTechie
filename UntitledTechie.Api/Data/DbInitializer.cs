using System;
using System.Collections.Generic;
using System.Linq;
using UntitledTechie.Api.Entities;

namespace UntitledTechie.Api.Data
{
    public class DbInitializer
    {

        private static readonly Guid _defaultAvatarId = new Guid("ed28c9f4-05ae-4930-bd15-30dc808438e5");
        private static readonly Guid _defaultImageId = new Guid("6e1bda32-25e5-4a9c-9837-f4b3aa6a970f");
        private static readonly Guid _defaultAdminId = new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9");
        private static readonly Guid _defaultBotId = new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d");
        public static void Initialize(TechieContext context)
        {
            context.Database.EnsureCreated();

            //Initialize Accounts
            if (context.Accounts.Any())
            {
                return;
            }

            List<AccountEntity> accounts = new List<AccountEntity>();
            accounts.Add(new AccountEntity() { Id = _defaultAdminId, Username = "TechieAdmin", AvatarImageId = _defaultAvatarId });
            accounts.Add(new AccountEntity() { Id = _defaultBotId, Username = "TechieBot", AvatarImageId = _defaultAvatarId });

            context.Accounts.AddRange(accounts);
            context.SaveChanges();

            InitializePosts(context);
        }

        private static void InitializePosts(TechieContext context)
        {
            if (context.Posts.Any())
            {
                return;
            }

            int numberOfPosts = 5;
            List<PostEntity> posts = new List<PostEntity>();

            for (int i = 0; i < numberOfPosts; i++)
            {
                Guid authorId = (i % 2 == 0) ? _defaultBotId : _defaultAdminId;
                PostEntity subComment = new PostEntity()
                {
                    Caption = $"This is the {i} post",
                    NumberOfLikes = i,
                    ImageId = _defaultImageId,
                    CreatorId = authorId,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                };

                posts.Add(subComment);
            }

            context.Posts.AddRange(posts);
            context.SaveChanges();

            foreach (PostEntity post in posts)
            {
                InitializeComments(context, post);
            }
        }

        private static void InitializeComments(TechieContext context, PostEntity post)
        {
            int numberOfComments = 3;
            List<CommentEntity> comments = new List<CommentEntity>();

            for (int i = 0; i < numberOfComments; i++)
            {
                Guid authorId = (i % 2 == 0) ? _defaultBotId : _defaultAdminId;
                CommentEntity subComment = new CommentEntity()
                {
                    Description = $"This is the {i} comment",
                    PostId = post.Id,
                    CreatorId = authorId,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                };

                comments.Add(subComment);
            }

            context.Comments.AddRange(comments);
            context.SaveChanges();

            foreach (CommentEntity cmt in comments)
            {
                InitializeSubComments(context, cmt);
            }
        }

        private static void InitializeSubComments(TechieContext context, CommentEntity comment)
        {
            int numberOfSubComments = 5;
            List<SubCommentEntity> subComments = new List<SubCommentEntity>();

            for (int i = 0; i < numberOfSubComments; i++)
            {
                Guid authorId = (i % 2 == 0) ? _defaultBotId : _defaultAdminId;
                SubCommentEntity subComment = new SubCommentEntity()
                {
                    CommentId = comment.Id,
                    Description = $"This is the {i} sub-comment",
                    PostId = comment.PostId,
                    CreatorId = authorId,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                };

                subComments.Add(subComment);

            }

            context.SubComments.AddRange(subComments);
            context.SaveChanges();
        }
    }
}