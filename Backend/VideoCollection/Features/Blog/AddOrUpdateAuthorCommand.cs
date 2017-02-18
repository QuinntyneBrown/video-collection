using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VideoCollection.Features.Blog
{
    public class AddOrUpdateAuthorCommand
    {
        public class AddOrUpdateAuthorRequest : IRequest<AddOrUpdateAuthorResponse>
        {
            public AuthorApiModel Author { get; set; }
        }

        public class AddOrUpdateAuthorResponse { }

        public class AddOrUpdateAuthorHandler : IAsyncRequestHandler<AddOrUpdateAuthorRequest, AddOrUpdateAuthorResponse>
        {
            public AddOrUpdateAuthorHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateAuthorResponse> Handle(AddOrUpdateAuthorRequest request)
            {
                var entity = await _dataContext.Authors
                    .SingleOrDefaultAsync(x => x.Id == request.Author.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Authors.Add(entity = new Author());
                entity.Firstname = request.Author.Firstname;
                entity.Lastname= request.Author.Lastname;

                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateAuthorResponse() { };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
