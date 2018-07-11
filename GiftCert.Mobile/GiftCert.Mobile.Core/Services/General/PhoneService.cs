using GiftCert.Mobile.Core.Contracts.Services.General;
using Plugin.Messaging;

namespace GiftCert.Mobile.Core.Services.General
{
    public class PhoneService: IPhoneService
    {
        public void MakePhoneCall()
        {
            CrossMessaging.Current.PhoneDialer.MakePhoneCall("5554885002");
        }
    }
}
