using DedAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DedAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        public EntryModel Entry { get; set; }
        public EntryPage(EntryModel entryModel)
        {
            InitializeComponent();
            Entry = entryModel;
            this.BindingContext = this;
            LBHTTPS.Text = Entry.HTTPS ? "Поддерживает HTTPS" : "Не поддерживает HTTPS";
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Uri uri = new Uri(Entry.Link);

            await Browser.OpenAsync(uri);
        }
    }
}