using VideoCollection.Data.Models;

namespace VideoCollection.Features.Tenants
{
    public class TenantApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromTenant<TModel>(Tenant tenant) where
            TModel : TenantApiModel, new()
        {
            var model = new TModel();
            model.Id = tenant.Id;
            return model;
        }

        public static TenantApiModel FromTenant(Tenant tenant)
            => FromTenant<TenantApiModel>(tenant);

    }
}
