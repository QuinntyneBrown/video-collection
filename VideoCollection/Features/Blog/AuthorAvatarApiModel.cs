using VideoCollection.Data.Models;

namespace VideoCollection.Features.Blog
{
    public class AuthorAvatarApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromAuthorAvatar<TModel>(AuthorAvatar authorAvatar) where
            TModel : AuthorAvatarApiModel, new()
        {
            var model = new TModel();
            model.Id = authorAvatar.Id;
            return model;
        }

        public static AuthorAvatarApiModel FromAuthorAvatar(AuthorAvatar authorAvatar)
            => FromAuthorAvatar<AuthorAvatarApiModel>(authorAvatar);

    }
}
