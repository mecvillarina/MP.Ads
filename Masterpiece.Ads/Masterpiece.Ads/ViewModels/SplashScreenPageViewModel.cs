using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterpiece.Ads.Core.ViewModels
{
    public class SplashScreenPageViewModel : ViewModelBase
    {
        public SplashScreenPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
