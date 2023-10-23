// Purpose: To create a database context for the CRUDAPP

using Microsoft.EntityFrameworkCore;

namespace CRUDAPP.Data


{
    internal sealed class AppDbContext : DbContext

    {
        public DbSet<Post> Posts {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite(connectionString:"Data Source=./Data/Posts.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            Post[] postsToSeed = new Post[6];

            for (int i = 0; i < postsToSeed.Length; i++)
            {
                postsToSeed[i] = new Post
                {
                    PostId = i + 1,
                    Title = $"Post {i + 1}",
                    Content = $"This is the content for post {i + 1}"
                };
            }

            modelBuilder.Entity<Post>().HasData(postsToSeed);
        }
        
    }
}