using Masterpiece.Ads.Core.PubSubEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

namespace Masterpiece.Ads.Core.ViewModels
{
    public class RewardedAdsPageViewModel : ViewModelBase
    {
        public RewardedAdsPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            Title = "Rewarded Ads";
            TappedMenuCommand = new DelegateCommand(() => EventAggregator.GetEvent<HamburgerTappedEvent>().Publish());
        }

        public DelegateCommand TappedMenuCommand { get; private set; }
    }
}
