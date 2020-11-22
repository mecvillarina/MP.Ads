using Prism.Navigation;
using System.Threading.Tasks;

namespace Masterpiece.Ads.Core.ViewModels
{
    public class SplashScreenPageViewModel : ViewModelBase
    {
        public SplashScreenPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await Task.Delay(10);
            await NavigationService.NavigateAsync("../MainPage");
        }
    }
}
