using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.HTMLContents
{
    public class RemoveHTMLContentCommand
    {
        public class RemoveHTMLContentRequest : IRequest<RemoveHTMLContentResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveHTMLContentResponse { }

        public class RemoveHTMLContentHandler : IAsyncRequestHandler<RemoveHTMLContentRequest, RemoveHTMLContentResponse>
        {
            public RemoveHTMLContentHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveHTMLContentResponse> Handle(RemoveHTMLContentRequest request)
            {
                var hTMLContent = await _dataContext.HTMLContents.FindAsync(request.Id);
                hTMLContent.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveHTMLContentResponse();
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
