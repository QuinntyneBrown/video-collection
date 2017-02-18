using VideoCollection.Data.Models;

namespace VideoCollection.Features.Blog
{
    public class AuthorApiModel
    {        
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public AuthorAvatarApiModel Avatar { get; set; }

        public static TModel FromAuthor<TModel>(Author author) where
            TModel : AuthorApiModel, new()
        {
            var model = new TModel();
            model.Id = author.Id;
            model.Firstname = author.Firstname;
            model.Lastname = author.Lastname;
            model.Avatar = AuthorAvatarApiModel.FromAuthorAvatar(author.AuthorAvatar);
            return model;
        }

        public static AuthorApiModel FromAuthor(Author author)
            => FromAuthor<AuthorApiModel>(author);

    }
}
