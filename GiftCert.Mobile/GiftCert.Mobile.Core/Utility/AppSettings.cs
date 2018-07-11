using GiftCert.Mobile.Core.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using GiftCert.Mobile.Core.Extensions;

namespace GiftCert.Mobile.Core.Utility
{
    public static class AppSettings
    {
        private static ISettings Settings => CrossSettings.Current;

        public static User User
        {
            get => Settings.GetValueOrDefault(nameof(User), default(User));

            set => Settings.AddOrUpdateValue(nameof(User), value);
        }
    }
}
