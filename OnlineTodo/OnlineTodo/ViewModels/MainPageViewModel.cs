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
            // Task untuk menambahkan item baru ke dalam list dan database

            await todoTable.InsertAsync(_item);
            Items.Add(_item);                                    
        }

        public async Task UpdateCheckedItem (TodoItem _item)
        {
            // Digunakan untuk update database di mana item yang di-check
            // akan memiliki nilai Checked = true
            // dan juga akan menghapus item yang telah dicek dari list

            await todoTable.UpdateAsync(_item);
            Items.Remove(_item);            
        }        
    }
}

