using System;
using System.Threading.Tasks;
using Akavache;
using GiftCert.Mobile.Core.Constants;
using GiftCert.Mobile.Core.Contracts.Repository;
using GiftCert.Mobile.Core.Contracts.Services.Data;
using GiftCert.Mobile.Core.Models;

namespace GiftCert.Mobile.Core.Services.Data
{
    public class ShoppingCartDataService : BaseService, IShoppingCartDataService
    {
        private readonly IGenericRepository _genericRepository;

        public ShoppingCartDataService(IGenericRepository genericRepository, IBlobCache cache = null) : base(cache)
        {
            _genericRepository = genericRepository;
        }

        public async Task<ShoppingCart> GetShoppingCart(string userId)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.ShoppingCartEndpoint}/{userId}"
            };

            var shoppingCart = await _genericRepository.GetAsync<ShoppingCart>(builder.ToString());

            return shoppingCart;
        }

        public async Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.AddShoppingCartItemEndpoint
            };

            var userShoppingCartItem = new UserShoppingCartItem
            {
                ShoppingCartItem = shoppingCartItem,
                UserId = userId
            };

            var result =
                await _genericRepository.PostAsync(builder.ToString(), userShoppingCartItem);

            return shoppingCartItem;
        }
    }
}
