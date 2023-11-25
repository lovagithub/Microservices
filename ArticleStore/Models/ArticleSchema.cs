namespace ArticleStore.Models
{
    public class ArticleSchema : IArticle
    {
        public string ArticleNamber { get; set; } = null!;
        public string? EAN { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string ArticleType { get; set; } = null!;
    }

    public interface IArticle
    {
    }
}
