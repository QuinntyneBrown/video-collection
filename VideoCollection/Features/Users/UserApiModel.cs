using VideoCollection.Data.Models;

namespace VideoCollection.Features.Users
{
    public class UserApiModel
    {        
        public int Id { get; set; }
        public string Username { get; set; }
        
        public static TModel FromUser<TModel>(User user) where
            TModel : UserApiModel, new()
        {
            var model = new TModel();
            model.Id = user.Id;
            model.Username = user.Username;
            return model;
        }

        public static UserApiModel FromUser(User user)
            => FromUser<UserApiModel>(user);

    }
}
