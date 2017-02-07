using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Search
{
    public class MergeOrUploadArticlesCommand
    {
        public class MergeOrUploadArticlesRequest : IRequest<MergeOrUploadArticlesResponse>
        {
            public MergeOrUploadArticlesRequest()
            {

            }
        }

        public class MergeOrUploadArticlesResponse
        {
            public MergeOrUploadArticlesResponse()
            {

            }
        }

        public class MergeOrUploadArticlesHandler : IAsyncRequestHandler<MergeOrUploadArticlesRequest, MergeOrUploadArticlesResponse>
        {
            public MergeOrUploadArticlesHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<MergeOrUploadArticlesResponse> Handle(MergeOrUploadArticlesRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
