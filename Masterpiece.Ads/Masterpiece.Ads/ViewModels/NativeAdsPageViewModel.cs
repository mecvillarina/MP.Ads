using Masterpiece.Ads.Core.PubSubEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;

namespace Masterpiece.Ads.Core.ViewModels
{
    public class NativeAdsPageViewModel : ViewModelBase
    {
        public NativeAdsPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, null, eventAggregator)
        {
            Title = "Native Ads";
            TappedMenuCommand = new DelegateCommand(() => EventAggregator.GetEvent<HamburgerTappedEvent>().Publish());
        }

        public DelegateCommand TappedMenuCommand { get; private set; }
    }
}
