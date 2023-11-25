using ArticleStore.Entities;

namespace ArticleStore.Models;

public class Article 
{
    public string ArticleNamber { get; set; } = null!;
    public string? EAN { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }

    public static implicit operator Article(ArticleEntity entity)
    {
        return new Article
        {
            ArticleNamber = entity.ArticleNamber,
            EAN = entity.EAN,
            Name = entity.Name,
            Description = entity.Description,
            UnitPrice = entity.UnitPrice

        };
    }
  
}
