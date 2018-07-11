﻿using System.Threading.Tasks;
using System.Windows.Input;
using GiftCert.Mobile.Core.Constants;
using GiftCert.Mobile.Core.Contracts.Services.General;
using GiftCert.Mobile.Core.Models;
using GiftCert.Mobile.Core.ViewModels.Base;
using Xamarin.Forms;

namespace GiftCert.Mobile.Core.ViewModels
{
    public class PieDetailViewModel: ViewModelBase
    {
        private Pie _selectedPie;

        public PieDetailViewModel(IConnectionService connectionService, 
            INavigationService navigationService, IDialogService dialogService) 
            : base(connectionService, navigationService, dialogService)
        { }

        public ICommand AddToCartCommand => new Command(OnAddToCart);
        public ICommand ReadDescriptionCommand => new Command(OnReadDescription);

        public Pie SelectedPie
        {
            get => _selectedPie;
            set
            {
                _selectedPie = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            SelectedPie = (Pie) data;
        }

        private async void OnAddToCart()
        {
            MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, SelectedPie);
            await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
        }

        private void OnReadDescription()
        {
            DependencyService.Get<ITextToSpeech>().ReadText(SelectedPie.LongDescription);
        }
    }
}
