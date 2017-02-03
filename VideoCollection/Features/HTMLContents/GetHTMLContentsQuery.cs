using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.HTMLContents
{
    public class GetHTMLContentsQuery
    {
        public class GetHTMLContentsRequest : IRequest<GetHTMLContentsResponse> { }

        public class GetHTMLContentsResponse
        {
            public ICollection<HTMLContentApiModel> HTMLContents { get; set; } = new HashSet<HTMLContentApiModel>();
        }

        public class GetHTMLContentsHandler : IAsyncRequestHandler<GetHTMLContentsRequest, GetHTMLContentsResponse>
        {
            public GetHTMLContentsHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetHTMLContentsResponse> Handle(GetHTMLContentsRequest request)
            {
                var hTMLContents = await _dataContext.HTMLContents.ToListAsync();
                return new GetHTMLContentsResponse()
                {
                    HTMLContents = hTMLContents.Select(x => HTMLContentApiModel.FromHTMLContent(x)).ToList()
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
