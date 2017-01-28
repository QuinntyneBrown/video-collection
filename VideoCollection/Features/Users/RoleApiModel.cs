using VideoCollection.Data.Models;

namespace VideoCollection.Features.Users
{
    public class RoleApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromRole<TModel>(Role role) where
            TModel : RoleApiModel, new()
        {
            var model = new TModel();
            model.Id = role.Id;
            return model;
        }

        public static RoleApiModel FromRole(Role role)
            => FromRole<RoleApiModel>(role);

    }
}
