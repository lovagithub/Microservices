
namespace Shared.Interfaces;

internal interface IArticle
{
    public string ArticleNamber { get; set; }
    public string? EAN { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public string ArticleType { get; set; }

}
