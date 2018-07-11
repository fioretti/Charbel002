using System.Threading.Tasks;
using GiftCert.Mobile.Core.Contracts.Services.General;
using GiftCert.Mobile.Core.ViewModels.Base;

namespace GiftCert.Mobile.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private MenuViewModel _menuViewModel;

        public MainViewModel(IConnectionService connectionService, 
            INavigationService navigationService, IDialogService dialogService, 
            MenuViewModel menuViewModel) 
            : base(connectionService, navigationService, dialogService)
        {
            _menuViewModel = menuViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get => _menuViewModel;
            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            await Task.WhenAll
            (
                _menuViewModel.InitializeAsync(data),
                _navigationService.NavigateToAsync<HomeViewModel>()
            );
        }
    }
}