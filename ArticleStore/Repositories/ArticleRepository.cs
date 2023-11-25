using ArticleStore.Contexts;
using ArticleStore.Entities;
using Shared.Cenerics;

namespace ArticleStore.Repositories;

public class ArticleRepository : Repository<ArticleEntity, DataContext>
{    
    private readonly DataContext _context;
    public ArticleRepository(DataContext context) : base(context)        
    {
        _context = context;
    }
}
