using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.DigitalAssets
{
    public class GetDigitalAssetByIdQuery
    {
        public class GetDigitalAssetByIdRequest : IAsyncRequest<GetDigitalAssetByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetDigitalAssetByIdResponse
        {
            public DigitalAssetApiModel DigitalAsset { get; set; } 
		}

        public class GetDigitalAssetByIdHandler : IAsyncRequestHandler<GetDigitalAssetByIdRequest, GetDigitalAssetByIdResponse>
        {
            public GetDigitalAssetByIdHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetDigitalAssetByIdResponse> Handle(GetDigitalAssetByIdRequest request)
            {                
                return new GetDigitalAssetByIdResponse()
                {
                    DigitalAsset = DigitalAssetApiModel.FromDigitalAsset(await _dataContext.DigitalAssets.FindAsync(request.Id))
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
