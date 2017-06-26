using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceMovieDownload.PageViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServiceMovieDownload.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
            //TopRatedListView.ItemSelected += (sender, e) => {
            //    ((ListView)sender).SelectedItem = null;
            //};
            //NowPlayingListView.ItemSelected += (sender, e) => {
            //    ((ListView)sender).SelectedItem = null;
            //};
            //PopularListView.ItemSelected += (sender, e) => {
            //    ((ListView)sender).SelectedItem = null;
            //};
        }
    }
}
