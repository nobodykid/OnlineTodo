using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using OnlineTodo.Models;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

namespace OnlineTodo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MobileServiceCollection<TodoItem, TodoItem> Items;
        public IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();

        public async Task AddNewItem (TodoItem _item)
        {
            // Menambahkan Item baru ke dalam list dan database

            await todoTable.InsertAsync(_item);
            Items.Add(_item);
                        
            // also provide offline features
        }

        public async Task UpdateCheckedItem (TodoItem _item)
        {
            // Digunakan untuk update database di mana Item yang di-check
            // akan memiliki nilai Checked = true

            await todoTable.UpdateAsync(_item);
            Items.Remove(_item);            

            //await SyncAsync(); // offline sync
        }        
    }
}

