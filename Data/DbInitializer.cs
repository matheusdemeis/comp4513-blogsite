using Bogus;
using comp4513_blogsite.Models;
using Microsoft.EntityFrameworkCore;

namespace comp4513_blogsite.Data;

public static class DbInitializer
{
    public static void Initialize(BlogContext context)
    {
        if (context.Posts.Any())
        {
            return;
        }

        var authorId = 1;

        var authorFaker = new Faker<Author>().Rules((f, a) =>
        {
            a.Id = authorId++;
            a.FirstName = f.Name.FirstName();
            a.LastName = f.Name.LastName();
        });

        List<Author> authors = authorFaker.Generate(3);

        var postId = 1;

        var postFaker = new Faker<Post>().Rules((f, p) =>
        {
            p.Id = postId++;
            p.Title = f.Lorem.Sentence();
            p.Content = f.Lorem.Paragraphs(5);
            p.Author = f.PickRandom(authors);
        });

        List<Post> posts = postFaker.Generate(5);

        context.Posts.AddRange(posts);
        context.SaveChanges();
    }
}
