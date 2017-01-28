using MediatR;

namespace VideoCollection.Security
{
    public class GetClaimsForUserRequest: IAsyncRequest<GetClaimsForUserResponse>
    {
        public GetClaimsForUserRequest(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}
