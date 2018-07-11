using System;
using System.Threading.Tasks;
using GiftCert.Mobile.Core.Constants;
using GiftCert.Mobile.Core.Contracts.Repository;
using GiftCert.Mobile.Core.Contracts.Services.Data;
using GiftCert.Mobile.Core.Models;

namespace GiftCert.Mobile.Core.Services.Data
{
    public class OrderDataService : IOrderDataService
    {
        private readonly IGenericRepository _genericRepository;

        public OrderDataService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.PlaceOrderEndpoint
            };

            var result =
                await _genericRepository.PostAsync<Order>(builder.ToString(), order);

            return order;
        }
    }
}
