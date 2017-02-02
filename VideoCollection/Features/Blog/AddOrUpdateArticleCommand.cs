using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Blog
{
    public class AddOrUpdateArticleCommand
    {
        public class AddOrUpdateArticleRequest : IRequest<AddOrUpdateArticleResponse>
        {
            public ArticleApiModel Article { get; set; }
        }

        public class AddOrUpdateArticleResponse
        {

        }

        public class AddOrUpdateArticleHandler : IAsyncRequestHandler<AddOrUpdateArticleRequest, AddOrUpdateArticleResponse>
        {
            public AddOrUpdateArticleHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateArticleResponse> Handle(AddOrUpdateArticleRequest request)
            {
                var entity = await _dataContext.Articles
                    .SingleOrDefaultAsync(x => x.Id == request.Article.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Articles.Add(entity = new Article());
                entity.Name = request.Article.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateArticleResponse()
                {

                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
