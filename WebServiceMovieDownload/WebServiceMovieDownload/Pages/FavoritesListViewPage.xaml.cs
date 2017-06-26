using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebServiceMovieDownload.PageViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServiceMovieDownload.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesListViewPage : ContentPage
    {

        public FavoritesListViewPage()
        {
            InitializeComponent();


            this.BindingContext = new FavoritesListViewPageViewModel();
        }

    }
}