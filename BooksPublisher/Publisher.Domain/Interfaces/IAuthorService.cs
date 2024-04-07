using Publisher.Domain.Entities;

namespace Publisher.Domain.Interfaces;

public interface IAuthorService
{
    Task AddAuthor(Author author);

    Task<IReadOnlyCollection<Author>> GetAuthors();
}