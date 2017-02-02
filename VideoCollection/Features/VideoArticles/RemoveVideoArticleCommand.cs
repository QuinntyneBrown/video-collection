using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.VideoArticles
{
    public class RemoveVideoArticleCommand
    {
        public class RemoveVideoArticleRequest : IRequest<RemoveVideoArticleResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveVideoArticleResponse { }

        public class RemoveVideoArticleHandler : IAsyncRequestHandler<RemoveVideoArticleRequest, RemoveVideoArticleResponse>
        {
            public RemoveVideoArticleHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveVideoArticleResponse> Handle(RemoveVideoArticleRequest request)
            {
                var videoArticle = await _dataContext.VideoArticles.FindAsync(request.Id);
                videoArticle.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveVideoArticleResponse();
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
