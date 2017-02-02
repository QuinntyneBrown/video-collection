using VideoCollection.Data.Models;

namespace VideoCollection.Features.VideoArticles
{
    public class VideoArticleApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromVideoArticle<TModel>(VideoArticle videoArticle) where
            TModel : VideoArticleApiModel, new()
        {
            var model = new TModel();
            model.Id = videoArticle.Id;
            return model;
        }

        public static VideoArticleApiModel FromVideoArticle(VideoArticle videoArticle)
            => FromVideoArticle<VideoArticleApiModel>(videoArticle);

    }
}
