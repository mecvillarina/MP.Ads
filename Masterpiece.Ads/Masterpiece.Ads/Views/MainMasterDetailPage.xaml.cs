﻿using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Masterpiece.Ads.Core.Views
{
    public partial class MainMasterDetailPage : Xamarin.Forms.MasterDetailPage
    {
        public MainMasterDetailPage()
        {
            InitializeComponent();

            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BackgroundColor = Color.White;
        }
    }
}