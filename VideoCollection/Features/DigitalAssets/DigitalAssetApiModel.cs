using VideoCollection.Data.Models;

namespace VideoCollection.Features.DigitalAssets
{
    public class DigitalAssetApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromDigitalAsset<TModel>(DigitalAsset digitalAsset) where
            TModel : DigitalAssetApiModel, new()
        {
            var model = new TModel();
            model.Id = digitalAsset.Id;
            return model;
        }

        public static DigitalAssetApiModel FromDigitalAsset(DigitalAsset digitalAsset)
            => FromDigitalAsset<DigitalAssetApiModel>(digitalAsset);

    }
}
