using Prism.Navigation;

namespace Masterpiece.Ads.Core.Models
{
    public class HamburgerNavigateModel
    {
        public string Path { get; set; }
        public INavigationParameters Parameters { get; set; } 
    }
}
