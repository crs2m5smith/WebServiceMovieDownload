using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceMovieDownload.Models;
using WebServiceMovieDownload.PageViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServiceMovieDownload.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage(MovieModel model)
        {
            InitializeComponent();
            this.BindingContext = new MovieDetailPageViewModel(model ?? null);

        }

        public MovieDetailPage() : this(null) { }
    }
}