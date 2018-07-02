using GiftCert.Core.Model;
using GiftCert.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCert.Core.Service
{
    public class HotDogDataService
    {
        private static GiftCertRepository giftCertRepository = new GiftCertRepository();

        public List<HotDog> GetAllGiftCerts()
        {
            return giftCertRepository.GetAllHotDogs();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return giftCertRepository.GetGroupedHotDogs();
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            return giftCertRepository.GetHotDogsForGroup(hotDogGroupId);
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            return giftCertRepository.GetFavoriteHotDogs();
        }

        public HotDog GetHotDogById(int hotDogId)
        {
            return giftCertRepository.GetHotDogById(hotDogId);
        }
    }
}
