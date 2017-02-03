using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.HTMLContents
{
    public class GetHTMLContentByIdQuery
    {
        public class GetHTMLContentByIdRequest : IRequest<GetHTMLContentByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetHTMLContentByIdResponse
        {
            public HTMLContentApiModel HTMLContent { get; set; } 
		}

        public class GetHTMLContentByIdHandler : IAsyncRequestHandler<GetHTMLContentByIdRequest, GetHTMLContentByIdResponse>
        {
            public GetHTMLContentByIdHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetHTMLContentByIdResponse> Handle(GetHTMLContentByIdRequest request)
            {                
                return new GetHTMLContentByIdResponse()
                {
                    HTMLContent = HTMLContentApiModel.FromHTMLContent(await _dataContext.HTMLContents.FindAsync(request.Id))
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
