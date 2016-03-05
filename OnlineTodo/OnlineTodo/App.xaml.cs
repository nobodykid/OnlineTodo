using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Microsoft.WindowsAzure.MobileServices;

namespace OnlineTodo
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    sealed partial class App : Template10.Common.BootStrapper
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://samplemobilebackend.azurewebsites.net");

        public App() { InitializeComponent(); }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            await Task.CompletedTask;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            NavigationService.Navigate(typeof(Views.MainPage));
            await Task.CompletedTask;
        }
    }
}

