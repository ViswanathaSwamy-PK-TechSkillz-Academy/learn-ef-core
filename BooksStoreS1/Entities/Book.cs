namespace BooksStoreS1.Entities;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public DateTime PublishedOn { get; set; }

    public string ISBN { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public decimal Price { get; set; }

    public int Pages { get; set; }

    public string PictureUrl { get; set; } = string.Empty;
}
