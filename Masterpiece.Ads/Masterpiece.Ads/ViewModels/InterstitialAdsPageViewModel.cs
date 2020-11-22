using Masterpiece.Ads.Core.PubSubEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;

namespace Masterpiece.Ads.Core.ViewModels
{
    public class InterstitialAdsPageViewModel : ViewModelBase
    {
        public InterstitialAdsPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            Title = "Interstitial Ads";
            TappedMenuCommand = new DelegateCommand(() => EventAggregator.GetEvent<HamburgerTappedEvent>().Publish());
        }

        public DelegateCommand TappedMenuCommand { get; private set; }
    }
}
