using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> contextOptions) : base(contextOptions)
    { }
    public DbSet<Book> Books { get; set; } = default!;
}

