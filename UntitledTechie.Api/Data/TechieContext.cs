using Microsoft.EntityFrameworkCore;
using UntitledTechie.Api.Entities;

namespace UntitledTechie.Api.Data
{
    public class TechieContext : DbContext
    {
        public TechieContext(DbContextOptions<TechieContext> options)
            : base(options)
        {

        }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<SubCommentEntity> SubComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>()
                .HasMany(acc => acc.Posts)
                .WithOne(p => p.Creator)
                .HasForeignKey(p => p.CreatorId);

            modelBuilder.Entity<PostEntity>()
                .HasMany(p => p.Comments)
                .WithOne()
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommentEntity>()
                .HasOne(cmt => cmt.Creator)
                .WithMany()
                .HasForeignKey(cmt => cmt.CreatorId);

            modelBuilder.Entity<SubCommentEntity>()
                .HasOne(sub => sub.Creator)
                .WithMany()
                .HasForeignKey(sub => sub.CreatorId);

            modelBuilder.Entity<CommentEntity>()
                .HasMany(cmt => cmt.SubComments)
                .WithOne()
                .HasForeignKey(sub => sub.CommentId)
                .OnDelete(DeleteBehavior.Restrict);            
        }

    }
}