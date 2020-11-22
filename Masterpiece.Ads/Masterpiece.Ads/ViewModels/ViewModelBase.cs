using Acr.UserDialogs;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

namespace Masterpiece.Ads.Core.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IUserDialogs UserDialogs { get; private set; }
        protected IEventAggregator EventAggregator { get; private set; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        public ViewModelBase(INavigationService navigationService, IUserDialogs userDialogs) : this(navigationService)
        {
            UserDialogs = userDialogs;
        }

        public ViewModelBase(INavigationService navigationService, IUserDialogs userDialogs,IEventAggregator eventAggregator) : this(navigationService, userDialogs)
        {
            EventAggregator = eventAggregator;
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
