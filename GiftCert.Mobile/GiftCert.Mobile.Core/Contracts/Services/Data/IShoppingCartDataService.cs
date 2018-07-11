using System.Threading.Tasks;
using GiftCert.Mobile.Core.Models;

namespace GiftCert.Mobile.Core.Contracts.Services.Data
{
    public interface IShoppingCartDataService
    {
        Task<ShoppingCart> GetShoppingCart(string userId);
        Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId);
    }
}
