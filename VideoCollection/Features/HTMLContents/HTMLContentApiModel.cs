using VideoCollection.Data.Models;

namespace VideoCollection.Features.HTMLContents
{
    public class HTMLContentApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public static TModel FromHTMLContent<TModel>(HTMLContent htmlContent) where
            TModel : HTMLContentApiModel, new()
        {
            var model = new TModel();
            model.Id = htmlContent.Id;
            model.Body = htmlContent.Body;
            return model;
        }

        public static HTMLContentApiModel FromHTMLContent(HTMLContent hTMLContent)
            => FromHTMLContent<HTMLContentApiModel>(hTMLContent);

    }
}
