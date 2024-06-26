﻿namespace Publisher.Domain.Entities;

public class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = string.Empty;

    public DateOnly PublishDate { get; set; }

    public decimal BasePrice { get; set; }

    public Author Author { get; set; } = new();

    public int AuthorId { get; set; }
}