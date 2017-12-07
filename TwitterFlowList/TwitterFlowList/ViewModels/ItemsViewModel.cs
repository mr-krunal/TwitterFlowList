using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TwitterFlowList
{
    public class ItemsViewModel : BaseViewModel
    {
        DLToolkit.Forms.Controls.FlowObservableCollection<Item> FlowItems { get; set; }
        public TrulyObservableCollection<Item> Items { get; set; }
        private TrulyObservableCollection<Item> _ItemsOnPage;
        public TrulyObservableCollection<Item> ItemsOnPage
        {
            get { return _ItemsOnPage; }
            set {                
                SetProperty(ref _ItemsOnPage, value);
            }
        }
        public Command LoadItemsCommand { get; set; }
        public Command AddItemsCommand { get; set; }
        public Command TapItemsCommand { get; set; }        

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new TrulyObservableCollection<Item>();
            FlowItems = new DLToolkit.Forms.Controls.FlowObservableCollection<Item>();
            ItemsOnPage = new TrulyObservableCollection<Item>();            
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemsCommand = new Command(async (obj) => await ExecuteAddItemsCommand(obj as string));
            //TapItemsCommand = new Command(async (obj) => await ExecuteTapItemsCommand(obj));
            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                    ItemsOnPage.Add(item);
                    FlowItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteAddItemsCommand(string newcategory)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                if (string.IsNullOrEmpty(newcategory))
                    return;
                Item item = new Item
                {
                    Text = newcategory,
                    Description = newcategory
                };
                Items.Add(item);
                ItemsOnPage.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteTapItemsCommand(object sender, EventArgs e)
        {
        }                
    }    
}