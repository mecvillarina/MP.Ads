using Acr.UserDialogs;
using MarcTron.Plugin.Interfaces;
using Masterpiece.Ads.Core.PubSubEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Masterpiece.Ads.Core.ViewModels
{
    public class PopupAdsPageViewModel : ViewModelBase
    {
        private readonly IMTAdmob _admobPlugin;

        public PopupAdsPageViewModel(INavigationService navigationService, IUserDialogs userDialogs, IEventAggregator eventAggregator, IMTAdmob admobPlugin) : base(navigationService, userDialogs, eventAggregator)
        {
            _admobPlugin = admobPlugin;

            Title = "Interstitial Ads";
            TappedMenuCommand = new DelegateCommand(() => EventAggregator.GetEvent<HamburgerTappedEvent>().Publish());
            DisplayInterstitialAdCommand = new DelegateCommand(async () => await OnDisplayInterstitialAd());
            DisplayInterstitialVideoAdCommand = new DelegateCommand(async () => await OnDisplayInsterstitialVideoAd());
            DisplayRewardedVideoAdCommand = new DelegateCommand(async () => await OnDisplayRewardedVideoAd());
        }

        public DelegateCommand TappedMenuCommand { get; private set; }
        public DelegateCommand DisplayInterstitialAdCommand { get; private set; }
        public DelegateCommand DisplayInterstitialVideoAdCommand { get; private set; }
        public DelegateCommand DisplayRewardedVideoAdCommand { get; private set; }

        private async Task OnDisplayInterstitialAd()
        {
            string adsId = string.Empty;

            switch (Device.RuntimePlatform)
            {
                case Device.Android: adsId = "ca-app-pub-3940256099942544/1033173712"; break;
                case Device.iOS: adsId = "ca-app-pub-3940256099942544/4411468910"; break;
            }

            UserDialogs.ShowLoading();
            _admobPlugin.LoadInterstitial(adsId);
            await Task.Delay(2000);
            UserDialogs.HideLoading();
            _admobPlugin.ShowInterstitial();
        }

        private async Task OnDisplayInsterstitialVideoAd()
        {
            string adsId = string.Empty;

            switch (Device.RuntimePlatform)
            {
                case Device.Android: adsId = "ca-app-pub-3940256099942544/8691691433"; break;
                case Device.iOS: adsId = "ca-app-pub-3940256099942544/5135589807"; break;
            }

            UserDialogs.ShowLoading();
            _admobPlugin.LoadInterstitial(adsId);
            await Task.Delay(2000);
            UserDialogs.HideLoading();
            _admobPlugin.ShowInterstitial();
        }

        private async Task OnDisplayRewardedVideoAd()
        {
            string adsId = string.Empty;

            switch (Device.RuntimePlatform)
            {
                case Device.Android: adsId = "ca-app-pub-3940256099942544/5224354917"; break;
                case Device.iOS: adsId = "ca-app-pub-3940256099942544/1712485313"; break;
            }

            UserDialogs.ShowLoading();
            _admobPlugin.LoadRewardedVideo(adsId);
            await Task.Delay(2000);
            UserDialogs.HideLoading();
            _admobPlugin.ShowRewardedVideo();
        }

    }
}
