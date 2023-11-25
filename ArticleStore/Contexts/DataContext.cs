using ArticleStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArticleStore.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DbContext> options) : base(options)
    {
    }
    public DbSet<ArticleEntity> Articles { get; set; }
}
