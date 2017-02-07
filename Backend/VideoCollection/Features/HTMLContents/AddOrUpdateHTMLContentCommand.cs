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
    public class AddOrUpdateHTMLContentCommand
    {
        public class AddOrUpdateHTMLContentRequest : IRequest<AddOrUpdateHTMLContentResponse>
        {
            public HTMLContentApiModel HTMLContent { get; set; }
        }

        public class AddOrUpdateHTMLContentResponse
        {

        }

        public class AddOrUpdateHTMLContentHandler : IAsyncRequestHandler<AddOrUpdateHTMLContentRequest, AddOrUpdateHTMLContentResponse>
        {
            public AddOrUpdateHTMLContentHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateHTMLContentResponse> Handle(AddOrUpdateHTMLContentRequest request)
            {
                var entity = await _dataContext.HTMLContents
                    .SingleOrDefaultAsync(x => x.Id == request.HTMLContent.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.HTMLContents.Add(entity = new HTMLContent());
                entity.Name = request.HTMLContent.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateHTMLContentResponse()
                {

                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
