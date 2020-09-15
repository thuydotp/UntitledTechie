using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UntitledTechie.Infrastructure.Entities;

namespace UntitledTechie.Infrastructure.Data
{
    public class DbInitializer
    {

        private static readonly Guid _defaultAvatarId = new Guid("ed28c9f4-05ae-4930-bd15-30dc808438e5");
        private static readonly Guid _defaultImageId = new Guid("6e1bda32-25e5-4a9c-9837-f4b3aa6a970f");
        private static readonly Guid _defaultAdminId = new Guid("da9ccf25-5ec4-4ea8-a693-2668492dbdf9");
        private static readonly Guid _defaultBotId = new Guid("8413033b-987d-412a-9cb7-1b6f92c2c87d");

        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>().HasData(SeedDataAccounts());
            PostEntity[] posts = SeedDataPosts();
            CommentEntity[] cmt = SeedDataComments(posts);
            modelBuilder.Entity<PostEntity>().HasData(posts);
            modelBuilder.Entity<CommentEntity>().HasData(cmt);
            modelBuilder.Entity<SubCommentEntity>().HasData(SeedDataSubcomments(cmt));
        }

        private static AccountEntity[] SeedDataAccounts()
        {
            List<AccountEntity> accounts = new List<AccountEntity>();
            accounts.Add(new AccountEntity() { Id = _defaultAdminId, Username = "TechieAdmin", AvatarImageId = _defaultAvatarId });
            accounts.Add(new AccountEntity() { Id = _defaultBotId, Username = "TechieBot", AvatarImageId = _defaultAvatarId });

            return accounts.ToArray();
        }

        private static PostEntity[] SeedDataPosts(int numberOfPosts = 5)
        {
            List<PostEntity> posts = new List<PostEntity>();
            for (int i = 0; i < numberOfPosts; i++)
            {
                Guid authorId = (i % 2 == 0) ? _defaultBotId : _defaultAdminId;
                PostEntity subComment = new PostEntity()
                {
                    Id = Guid.NewGuid(),
                    Caption = $"This is the {i} post",
                    NumberOfLikes = i,
                    ImageId = _defaultImageId,
                    CreatorId = authorId,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                };

                posts.Add(subComment);
            }
            return posts.ToArray();
        }

        private static CommentEntity[] SeedDataComments(PostEntity[] posts, int numberOfComments = 4)
        {
            List<CommentEntity> comments = new List<CommentEntity>();
            foreach (PostEntity post in posts)
            {
                for (int i = 0; i < numberOfComments; i++)
                {
                    Guid authorId = (i % 2 == 0) ? _defaultBotId : _defaultAdminId;
                    CommentEntity comment = new CommentEntity()
                    {
                        Id = Guid.NewGuid(),
                        Description = $"This is the {i} comment",
                        PostId = post.Id,
                        CreatorId = authorId,
                        CreatedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    };

                    comments.Add(comment);
                }
            }
            return comments.ToArray();
        }

        private static SubCommentEntity[] SeedDataSubcomments(CommentEntity[] comments, int numberOfSubComments = 5)
        {
            List<SubCommentEntity> subcomments = new List<SubCommentEntity>();

            foreach (CommentEntity comment in comments)
            {
                for (int i = 0; i < numberOfSubComments; i++)
                {
                    Guid authorId = (i % 2 == 0) ? _defaultBotId : _defaultAdminId;
                    SubCommentEntity subComment = new SubCommentEntity()
                    {
                        Id = Guid.NewGuid(),
                        CommentId = comment.Id,
                        Description = $"This is the {i} sub-comment",
                        PostId = comment.PostId,
                        CreatorId = authorId,
                        CreatedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    };
                    subcomments.Add(subComment);
                }
            }

            return subcomments.ToArray();
        }

        
    }
}