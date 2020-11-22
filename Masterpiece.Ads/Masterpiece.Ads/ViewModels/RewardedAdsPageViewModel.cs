using Acr.UserDialogs;
using MarcTron.Plugin.Interfaces;
using Masterpiece.Ads.Core.PubSubEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Masterpiece.Ads.Core.ViewModels
{
    public class RewardedAdsPageViewModel : ViewModelBase
    {
        private readonly IMTAdmob _admobPlugin;
        public RewardedAdsPageViewModel(INavigationService navigationService, IUserDialogs userDialogs, IEventAggregator eventAggregator, IMTAdmob admobPlugin) : base(navigationService, userDialogs, eventAggregator)
        {
            _admobPlugin = admobPlugin;

            Title = "Rewarded Ads";
            TappedMenuCommand = new DelegateCommand(() => EventAggregator.GetEvent<HamburgerTappedEvent>().Publish());
            DisplayVideoAdCommand = new DelegateCommand(async () => await OnDisplayVideoAd());
        }

        public DelegateCommand TappedMenuCommand { get; private set; }
        public DelegateCommand DisplayVideoAdCommand { get; private set; }

        private async Task OnDisplayVideoAd()
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
