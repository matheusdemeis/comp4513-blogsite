namespace comp4513_blogsite.Models;

public class Category
{
    public int Id {get; set;}

    public string Name {get; set;}

    public List<Post> Posts {get; set;}
}