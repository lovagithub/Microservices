using ArticleStore.Models;
using Shared.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleStore.Entities;

public class ArticleEntity : IArticle
{
    [Key]
    public string ArticleNamber { get; set; } = null!;
    public string? EAN { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }
    public string ArticleType { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Modified { get; set; } = DateTime.Now;


    public static implicit operator ArticleEntity(ArticleSchema schema)
    {
        return new ArticleEntity
        {
            ArticleNamber = schema.ArticleNamber,
            EAN = schema.EAN,
            Name = schema.Name,
            Description = schema.Description,
            UnitPrice = schema.UnitPrice,
            ArticleType = schema.ArticleType
        };
    }

}


