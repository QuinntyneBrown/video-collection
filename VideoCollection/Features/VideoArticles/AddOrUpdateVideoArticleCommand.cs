using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VideoCollection.Features.VideoArticles
{
    public class AddOrUpdateVideoArticleCommand
    {
        public class AddOrUpdateVideoArticleRequest : IRequest<AddOrUpdateVideoArticleResponse>
        {
            public VideoArticleApiModel VideoArticle { get; set; }
        }

        public class AddOrUpdateVideoArticleResponse { }

        public class AddOrUpdateVideoArticleHandler : IAsyncRequestHandler<AddOrUpdateVideoArticleRequest, AddOrUpdateVideoArticleResponse>
        {
            public AddOrUpdateVideoArticleHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateVideoArticleResponse> Handle(AddOrUpdateVideoArticleRequest request)
            {
                var entity = await _dataContext.VideoArticles
                    .SingleOrDefaultAsync(x => x.Id == request.VideoArticle.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.VideoArticles.Add(entity = new VideoArticle());
                entity.Name = request.VideoArticle.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateVideoArticleResponse()
                {

                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
