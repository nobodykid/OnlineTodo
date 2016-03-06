using System;
using Windows.UI.Xaml.Controls;
using OnlineTodo.ViewModels;
using OnlineTodo.Models;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace OnlineTodo.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel vm { get; set; } = new MainPageViewModel();

        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await vm.AddNewItem(new Models.TodoItem
            {
                Text = contentTxt.Text,
                Complete = false
            });

            await RefreshTodoItems();
        }

        private async void CheckBox_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            TodoItem item = cb.DataContext as TodoItem;
            await vm.UpdateCheckedItem(item);
        }

        private async Task RefreshTodoItems()
        {            
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems.
                vm.Items = await vm.todoTable
                    .Where(todoItem => todoItem.Complete == false)
                    .ToCollectionAsync();

                ItemList.ItemsSource = vm.Items;
            }
            catch (MobileServiceInvalidOperationException e)
            {
                await new MessageDialog(e.Message, "Error loading items").ShowAsync();
            }            
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await RefreshTodoItems();
        }
    }
}
