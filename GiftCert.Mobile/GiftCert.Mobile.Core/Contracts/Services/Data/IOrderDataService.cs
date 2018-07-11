using System.Threading.Tasks;
using GiftCert.Mobile.Core.Models;

namespace GiftCert.Mobile.Core.Contracts.Services.Data
{
    public interface IOrderDataService
    {
        Task<Order> PlaceOrder(Order order);
    }
}
