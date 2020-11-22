using System;
using System.Collections.Generic;
using System.Text;

namespace Masterpiece.Ads.Core.Common.Constants
{
    public static class ViewNames
    {
        public const string NavigationPage = nameof(NavigationPage);
        public const string SplashScreenPage = nameof(SplashScreenPage);
        public const string MainMasterDetailPage = nameof(MainMasterDetailPage);
        public const string MainPage = nameof(MainPage);
        public const string BannerAdsPage = nameof(BannerAdsPage);
        public const string InterstitialAdsPage = nameof(InterstitialAdsPage);
        public const string RewardedAdsPage = nameof(RewardedAdsPage);
        public const string NativeAdsPage = nameof(NativeAdsPage);

        public static string GetMainMasterPage()
        {
            return $"{MainMasterDetailPage}/{NavigationPage}/{BannerAdsPage}";
        }
    }
}
