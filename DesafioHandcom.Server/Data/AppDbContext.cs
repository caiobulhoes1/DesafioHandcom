using Microsoft.EntityFrameworkCore;

namespace DesafioHandcom.Data
{
	public class AppDbContext : DbContext
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<PostViewModel>()
				.HasOne(p => p.Author)
				.WithMany()
				.HasForeignKey(p => p.AuthorId);

			modelBuilder.Entity<PostViewModel>()
				.HasOne(p => p.Topic)
				.WithMany()
				.HasForeignKey(p => p.TopicId);

			modelBuilder.Entity<CommentViewModel>()
				.HasOne(c => c.Author)
				.WithMany()
				.HasForeignKey(c => c.AuthorId);

			modelBuilder.Entity<CommentViewModel>()
				.HasOne(c => c.Post)
				.WithMany()
				.HasForeignKey(c => c.PostId);
		}

		public AppDbContext(DbContextOptions options) : base(options) {
		 
		}

		public DbSet<UserModel> Users { get; set; }
		public DbSet<TopicModel> Topics { get; set; }
		public DbSet<PostModel> Posts { get; set; }
		public DbSet<CommentModel> Comments { get; set; }	
		
	}
}
