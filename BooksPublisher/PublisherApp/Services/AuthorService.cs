using Microsoft.EntityFrameworkCore;
using Publisher.Data;
using Publisher.Domain.Entities;
using Publisher.Domain.Interfaces;

namespace PublisherApp.Services;

public class AuthorService(PublishersDbContext context) : IAuthorService
{
    private readonly PublishersDbContext _context = context;

    public async Task AddAuthor(Author author)
    {
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<Author>> GetAuthors()
    {
        return await _context.Authors
                            .Include(a => a.Books)
                            .ToListAsync();
    }
}