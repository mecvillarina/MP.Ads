using Foundation;
using Masterpiece.Ads.Core;
using Prism;
using Prism.Ioc;
using UIKit;


namespace Masterpiece.Ads.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            InitLibraries(app, options);
            LoadApplication(new App(new IOSInitializer()));
            return base.FinishedLaunching(app, options);
        }

        private void InitLibraries(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            AiForms.Effects.iOS.Effects.Init();
        }
    }

    public class IOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
