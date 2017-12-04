using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace TwitterFlowList
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            //ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            /*if (viewModel.Items.Count == 0)
            {*/
            viewModel.LoadItemsCommand.Execute(null);
            if (viewModel.Items != null)
            {
                var referenceLabel = new Label { Text = "Foo", Opacity = 0 };
                var titleLabel = new Label { Text = "Foo" };

                var centerX = Constraint.RelativeToParent(parent => parent.Width / 2 - 100);
                var centerY = Constraint.RelativeToParent(parent => parent.Height / 2 - 100);
                //relChilds.Children.Add(referenceLabel, centerX, centerY);

                foreach (Item item in viewModel.Items)
                {
                    Label label = new Label()
                    {
                        Text = item.Text,
                        BackgroundColor = Color.Accent,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        VerticalOptions = LayoutOptions.StartAndExpand,
                        TextColor = Color.Black
                    };
                    //relChilds.Children.Add(label);
                    // relChilds.Children.Add(label,
                    //   Constraint.RelativeToView(referenceLabel, (parent, sibling) => sibling.X - sibling.Width / 2), // X
                    // centerY);
                }
            }
            //}                
        }

        private void entercategory_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(entercategory.Text))
            {
                viewModel.ItemsOnPage = new ObservableCollection<Item>(viewModel.Items.Where<Item>(x => x.Text.ToLower().Contains(entercategory.Text.ToLower()) == true).ToList());                
            }                
            else
                viewModel.ItemsOnPage = viewModel.Items;

            AddCategory.CommandParameter = entercategory.Text;
            viewModel.IsVisible = viewModel.ItemsOnPage.Count > 0 ? false : true;
        }
    }
}