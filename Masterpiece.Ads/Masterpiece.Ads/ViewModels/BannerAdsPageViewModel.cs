using Masterpiece.Ads.Core.PubSubEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;

namespace Masterpiece.Ads.Core.ViewModels
{
    public class BannerAdsPageViewModel : ViewModelBase
    {
        public BannerAdsPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            Title = "Banner Ads";
            TappedMenuCommand = new DelegateCommand(() => EventAggregator.GetEvent<HamburgerTappedEvent>().Publish());
        }

        public DelegateCommand TappedMenuCommand { get; private set; }
    }
}
