using VideoCollection.Data.Models;

namespace VideoCollection.Features.Playlists
{
    public class PlaylistApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromPlaylist<TModel>(Playlist playlist) where
            TModel : PlaylistApiModel, new()
        {
            var model = new TModel();
            model.Id = playlist.Id;
            return model;
        }

        public static PlaylistApiModel FromPlaylist(Playlist playlist)
            => FromPlaylist<PlaylistApiModel>(playlist);

    }
}
