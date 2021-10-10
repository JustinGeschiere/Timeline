using Microsoft.EntityFrameworkCore;
using Timeline.Data.Entities;

namespace Timeline.Data
{
	public class TimelineContext : DbContext
	{
		public DbSet<Person> Persons { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Token> Tokens { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.;Database=Timeline;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Single person <-> multiple posts
			modelBuilder.Entity<Person>()
				.HasMany(i => i.Posts)
				.WithOne(i => i.Author);

			// Single post <-> multiple comments
			modelBuilder.Entity<Post>()
				.HasMany(i => i.Comments)
				.WithOne(i => i.Post);

			// Single post -> multiple tokens
			modelBuilder.Entity<Post>()
				.HasMany(i => i.Tokens);

			// Single comment -> multiple tokens
			modelBuilder.Entity<Comment>()
				.HasMany(i => i.Tokens);
		}
	}
}
