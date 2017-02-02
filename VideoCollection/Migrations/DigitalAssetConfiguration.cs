using System.Data.Entity.Migrations;
using VideoCollection.Data;
using VideoCollection.Data.Models;

namespace VideoCollection.Migrations
{
    public class DigitalAssetConfiguration
    {
        public static void Seed(VideoCollectionDataContext context) {

            //context.DigitalAssets.AddOrUpdate(x => x.Name, new DigitalAsset()
            //{

            //});

            context.SaveChanges();
        }
    }
}
