using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Cli.Commands.Shared
{
    public class HelpCommand
    {
        public class HelpRequest : IRequest<HelpResponse> { }

        public class HelpResponse { }

        public class HelpHandler : IAsyncRequestHandler<HelpRequest, HelpResponse>
        {            
            public async Task<HelpResponse> Handle(HelpRequest request)
            {
				throw new System.NotImplementedException();
            }
        }
    }
}
