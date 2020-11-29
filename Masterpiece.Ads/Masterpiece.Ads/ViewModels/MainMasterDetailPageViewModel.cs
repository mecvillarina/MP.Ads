using Masterpiece.Ads.Core.Common.Constants;
using Masterpiece.Ads.Core.Models;
using Masterpiece.Ads.Core.PubSubEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Threading.Tasks;

namespace Masterpiece.Ads.Core.ViewModels
{
    public class MainMasterDetailPageViewModel : ViewModelBase
    {
        private readonly SubscriptionToken _hamburgerTappedEventSubscriptionToken;
        private readonly SubscriptionToken _hamburgerNavigateEventSubscriptionToken;
        private readonly SubscriptionToken _hamburgerNavigateModalEventSubscriptionToken;
        private readonly SubscriptionToken _hamburgerNavigateBackToRootEventSubscriptionToken;
        private readonly SubscriptionToken _hamburgerSetSwipeGestureEventSubscriptionToken;

        public MainMasterDetailPageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator) : base(navigationService, null, eventAggregator)
        {
            _hamburgerTappedEventSubscriptionToken = EventAggregator.GetEvent<HamburgerTappedEvent>().Subscribe(() => OnPresentToggle(true), ThreadOption.UIThread);
            _hamburgerNavigateEventSubscriptionToken = EventAggregator.GetEvent<HamburgerNavigateEvent>().Subscribe(async (model) => await OnHamburgerNavigate(model), ThreadOption.UIThread);
            _hamburgerNavigateModalEventSubscriptionToken = EventAggregator.GetEvent<HamburgerNavigateModalEvent>().Subscribe(async (model) => await OnHamburgerNavigateModal(model), ThreadOption.UIThread);
            _hamburgerNavigateBackToRootEventSubscriptionToken = EventAggregator.GetEvent<HamburgerNavigateBackToRootEvent>().Subscribe(async (defaultPage) => await OnHamburgerNavigateBackToRoot(defaultPage), ThreadOption.UIThread);
            _hamburgerSetSwipeGestureEventSubscriptionToken = EventAggregator.GetEvent<HamburgerSetSwipeGestureEvent>().Subscribe((val) => IsGestureEnabled = val, ThreadOption.UIThread);

            TapBannerAdsCommand = new DelegateCommand(async () => await OnTapBannerAds());
            TapInterstitialAndRewardedAdsCommand = new DelegateCommand(async () => await OnTapInterstitialAndRewardedAds());
            TapNativeAdsCommand = new DelegateCommand(async () => await OnTapNativeAds());
        }

        private async Task OnTapBannerAds() => await OnHamburgerNavigate(new HamburgerNavigateModel() { Path = ViewNames.BannerAdsPage });
        private async Task OnTapInterstitialAndRewardedAds() => await OnHamburgerNavigate(new HamburgerNavigateModel() { Path = ViewNames.PopupAdsPage });
        private async Task OnTapNativeAds() => await OnHamburgerNavigate(new HamburgerNavigateModel() { Path = ViewNames.NativeAdsPage });

        private bool _isPresented;
        public bool IsPresented
        {
            get => _isPresented;
            set => SetProperty(ref _isPresented, value);
        }

        private bool _isGestureEnabled;
        public bool IsGestureEnabled
        {
            get => _isGestureEnabled;
            set => SetProperty(ref _isGestureEnabled, value);
        }

        private void OnPresentToggle(bool isPresented)
        {
            IsPresented = isPresented;
        }

        private async Task OnHamburgerNavigate(HamburgerNavigateModel model)
        {
            IsGestureEnabled = false;
            await NavigationService.NavigateAsync($"{ViewNames.NavigationPage}/{model.Path}", model.Parameters, useModalNavigation: false, animated: false);
        }

        private async Task OnHamburgerNavigateModal(HamburgerNavigateModel model)
        {
            IsGestureEnabled = false;
            await NavigationService.NavigateAsync($"{model.Path}", model.Parameters, useModalNavigation: true, animated: false);
        }

        private async Task OnHamburgerNavigateBackToRoot(string defaultPage)
        {
            IsGestureEnabled = true;
            await NavigationService.NavigateAsync($"NavigationPage/{defaultPage}", null, useModalNavigation: false, animated: false);
        }

        public DelegateCommand TapBannerAdsCommand { get; private set; }
        public DelegateCommand TapInterstitialAndRewardedAdsCommand { get; private set; }
        public DelegateCommand TapNativeAdsCommand { get; private set; }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            IsGestureEnabled = true;
        }

        public override void Destroy()
        {
            base.Destroy();
            EventAggregator.GetEvent<HamburgerTappedEvent>().Unsubscribe(_hamburgerTappedEventSubscriptionToken);
            EventAggregator.GetEvent<HamburgerNavigateEvent>().Unsubscribe(_hamburgerNavigateEventSubscriptionToken);
            EventAggregator.GetEvent<HamburgerNavigateModalEvent>().Unsubscribe(_hamburgerNavigateModalEventSubscriptionToken);
            EventAggregator.GetEvent<HamburgerNavigateBackToRootEvent>().Unsubscribe(_hamburgerNavigateBackToRootEventSubscriptionToken);
            EventAggregator.GetEvent<HamburgerSetSwipeGestureEvent>().Unsubscribe(_hamburgerSetSwipeGestureEventSubscriptionToken);
        }
    }
}
