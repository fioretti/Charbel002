using System.Threading.Tasks;
using GiftCert.Mobile.Core.Models;

namespace GiftCert.Mobile.Core.Contracts.Services.Data
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Register(string firstName, string lastName, string email, string userName,
            string password);

        Task<AuthenticationResponse> Authenticate(string userName, string password);

        bool IsUserAuthenticated();
    }
}
