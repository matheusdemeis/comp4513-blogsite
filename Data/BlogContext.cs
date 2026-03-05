using comp4513_blogsite.Models;
using Microsoft.EntityFrameworkCore;

namespace comp4513_blogsite.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options) { }

    public DbSet<Post> Post {get; set;} = default!; // think of this as the database table
}