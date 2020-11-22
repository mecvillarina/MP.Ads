using Acr.UserDialogs;
using MarcTron.Plugin;
using Masterpiece.Ads.Core.Common.Constants;
using Masterpiece.Ads.Core.ViewModels;
using Masterpiece.Ads.Core.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Masterpiece.Ads.Core
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            CrossMTAdmob.Current.UserPersonalizedAds = true;
            await NavigationService.NavigateAsync($"{ViewNames.NavigationPage}/{ViewNames.SplashScreenPage}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SplashScreenPage, SplashScreenPageViewModel>();
            containerRegistry.RegisterForNavigation<MainMasterDetailPage, MainMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<BannerAdsPage, BannerAdsPageViewModel>();
            containerRegistry.RegisterForNavigation<InterstitialAdsPage, InterstitialAdsPageViewModel>();
            containerRegistry.RegisterForNavigation<RewardedAdsPage, RewardedAdsPageViewModel>();
            containerRegistry.RegisterForNavigation<NativeAdsPage, NativeAdsPageViewModel>();

            containerRegistry.RegisterInstance(CrossMTAdmob.Current);
            containerRegistry.RegisterInstance(UserDialogs.Instance);
        }
    }
}
