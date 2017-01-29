using VideoCollection.Data.Models;

namespace VideoCollection.Features.Videos
{
    public class VideoApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }

        public static TModel FromVideo<TModel>(Video video) where
            TModel : VideoApiModel, new()
        {
            var model = new TModel();
            model.Id = video.Id;
            return model;
        }

        public static VideoApiModel FromVideo(Video video)
            => FromVideo<VideoApiModel>(video);

    }
}
