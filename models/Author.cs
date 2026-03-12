namespace comp4513_blogsite.Models;

public class Author
{
    public int Id {get; set;}

    public string FirstName {get; set;}

    public string LastName {get; set;}

    public string Name => $"{LastName}, {FirstName}";

    public int AuthorId {get; set;}

    public Author AuthorId {get; set;}
}