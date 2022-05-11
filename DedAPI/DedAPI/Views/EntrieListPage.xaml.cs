using DedAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DedAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntrieListPage : ContentPage
    {
        public List<EntryModel> Entries { get; set; }
        public EntrieListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Entries = await App.RequestManager.GetEntrieModels();
            LVEntries.ItemsSource = Entries;
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBar.Text.ToLower();


            LVEntries.ItemsSource = Entries.Where(en => en.API.ToLower().Contains(searchText) || en.Description.ToLower().Contains(searchText));
        }

        private async void LVEntries_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var entry = LVEntries.SelectedItem as EntryModel;

            await Navigation.PushAsync(new EntryPage(entry));
        }
    }
}