using System.Threading.Tasks;
using netflixAPI.Contracts.V1.Requests;
using netflixAPI.Domain;

namespace netflixAPI.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(UserRegistrationRequest req);


        Task<AuthenticationResult> LoginAsync(UserLoginRequest req);


        Task<AuthenticationResult> RefreshTokenAsync(RefreshTokenRequest req);
    }
}