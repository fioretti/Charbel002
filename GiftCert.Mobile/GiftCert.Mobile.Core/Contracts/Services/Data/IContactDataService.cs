using System.Threading.Tasks;
using GiftCert.Mobile.Core.Models;

namespace GiftCert.Mobile.Core.Contracts.Services.Data
{
    public interface IContactDataService
    {
        Task<ContactInfo> AddContactInfo(ContactInfo contactInfo);
    }
}
