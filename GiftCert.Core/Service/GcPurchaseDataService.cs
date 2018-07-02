using GiftCert.Core.Model;
using GiftCert.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCert.Core.Service
{
    public class GcPurchaseDataService
    {
        private static GcPurchaseRepository gcPurchaseRepository = new GcPurchaseRepository();

        //public List<HotDog> GetAllGiftCerts()
        //{
        //    return giftCertRepository.GetAllHotDogs();
        //}

        //public List<HotDogGroup> GetGroupedHotDogs()
        //{
        //    return giftCertRepository.GetGroupedHotDogs();
        //}

        public List<GcPurchase> GetHotDogsForGroup(int hotDogGroupId)
        {
            return gcPurchaseRepository.GetGcPurchases();
        }

        public List<GcPurchase> GetFavoriteHotDogs()
        {
            return gcPurchaseRepository.GetGcPurchases();
        }

        public GcPurchase GetHotDogById(int orderId)
        {
            return gcPurchaseRepository.GetGcPurchaseById(orderId);
        }
    }
}
