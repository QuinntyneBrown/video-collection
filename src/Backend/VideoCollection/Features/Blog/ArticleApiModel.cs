using VideoCollection.Data.Models;

namespace VideoCollection.Features.Blog
{
    public class ArticleApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Teaser { get; set; }
        public string Body { get; set; }
        public AuthorApiModel Author { get; set; }

        public static TModel FromArticle<TModel>(Article article) where
            TModel : ArticleApiModel, new()
        {
            var model = new TModel();
            model.Id = article.Id;
            model.Title = article.Title;
            model.Slug = article.Slug;
            model.Teaser = article.Teaser;
            model.Body = article.Body;
            model.Author = AuthorApiModel.FromAuthor(article.Author);
            return model;
        }

        public static ArticleApiModel FromArticle(Article article)
            => FromArticle<ArticleApiModel>(article);
    }
}
