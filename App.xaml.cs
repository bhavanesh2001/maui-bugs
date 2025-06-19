using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace maui_bugs
{
    public partial class App : Application
    {
        private WeakReference? _leakyPageReference;

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(GetNavigationPage());
        }

        private static ContentPage CreateRootPage()
        {
            return new ContentPage
            {
                Title = "Root",
                Content = new VerticalStackLayout
                {
                    Children =
                    {
                        new Label { Text = "Root Page" },
                        new Button
                        {
                            Text = "Push Leaky Page",
                            Command = new Command(async () =>
                            {
                                if (Application.Current?.Windows[0].Page is NavigationPage nav)
                                {
                                    var page = new LeakyPage();
                                    await nav.PushAsync(page);
                                }
                            })
                        }
                    }
                }
            };
        }

        public static  NavigationPage GetNavigationPage()
        {
          return new NavigationPage(CreateRootPage());

        }

        public class LeakyPage : ContentPage
        {
            public LeakyPage()
            {
                Title = "LeakyPage";
                Content = new VerticalStackLayout
                {
                    Children =
                    {
                        new Label { Text = "I'm supposed to be gone!" },
                        new Button
                        {
                            Text = "Replace Window.Page",
                            Command = new Command(() =>
                            {
                                if(App.Current?.Windows[0] is Window currentWindow)
                                {
                                    currentWindow.Page = App.GetNavigationPage();
                                }
                            })
                        }
                    }
                };
            }
        }
    }
}