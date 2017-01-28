using VideoCollection.Data.Models;

namespace VideoCollection.Features.Playlists
{
    public class PlaylistItemApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromPlaylistItem<TModel>(PlaylistItem playlistItem) where
            TModel : PlaylistItemApiModel, new()
        {
            var model = new TModel();
            model.Id = playlistItem.Id;
            return model;
        }

        public static PlaylistItemApiModel FromPlaylistItem(PlaylistItem playlistItem)
            => FromPlaylistItem<PlaylistItemApiModel>(playlistItem);

    }
}
