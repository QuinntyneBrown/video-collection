using VideoCollection.Data.Models;

namespace VideoCollection.Features.Videos
{
    public class VideoApiModel
    {        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string YouTubeVideoId { get; set; }

        public static TModel FromVideo<TModel>(Video video) where
            TModel : VideoApiModel, new()
        {
            var model = new TModel();
            model.Id = video.Id;
            model.Title = video.Title;
            model.Abstract = video.Abstract;
            model.Description = video.Description;
            model.Category = video.Category;
            model.YouTubeVideoId = video.YouTubeVideoId;
            return model;
        }

        public static VideoApiModel FromVideo(Video video)
            => FromVideo<VideoApiModel>(video);

    }
}
