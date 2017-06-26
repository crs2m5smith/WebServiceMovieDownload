using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceMovieDownload.BasePageViewModels;
using WebServiceMovieDownload.Components;
using WebServiceMovieDownload.Globals;
using WebServiceMovieDownload.Models;
using WebServiceMovieDownload.Pages;
using Xamarin.Forms;

namespace WebServiceMovieDownload.PageViewModels
{
    public class FavoritesListViewPageViewModel : BasePageViewModel
    {
        private ObservableCollection<MovieModel> _favoritesMovies;

        public MovieModel _selectedItem;

        public FavoritesListViewPageViewModel()
        {
            this.Title = "Favorites";

            var model = DBConnection.db.GetFavorites() ;
            UpdateFavorites(model);
            this.RefreshCommand = new Command(async () =>
            {
                IsRefreshing = true;
                await RefreshFavorites();
                IsRefreshing = false;
            });

        }

        public ObservableCollection<MovieModel> FavoritesMovies
        {
            get
            {
                return _favoritesMovies;
            }
            set
            {
                _favoritesMovies = value;
                OnPropertyChanged("FavoritesMovies");
            }
        }
        public MovieModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnSelectedItem(_selectedItem);
                }
            }
        }
        public void OnSelectedItem(MovieModel model)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new MovieDetailPage(model));
            });
        }
        private async Task RefreshFavorites()
        {
            // get movies
            var model = DBConnection.db.GetFavorites();
            UpdateFavorites(model);

        }
        private async void UpdateFavorites(List<FavoriteModel> favorites)
        {
            await ShowLoading();
            var movieItems = new ObservableCollection<MovieModel>();

            foreach (var fav in favorites)
            {
                var movie = new MovieModel()
                {
                    Id = fav.MovieId,
                    Title = fav.Title,
                    ImageSource = (!string.IsNullOrEmpty(fav.PosterPath) ? ImageSource.FromUri(new Uri(string.Format(WebServiceEndPoints._posterPoint, fav.PosterPath))) : ImageSource.FromFile("icon.png")),
                    Overview = fav.Overview,
                    PosterPath = fav.PosterPath
                };
                movieItems.Add(movie);               
            }

            FavoritesMovies = movieItems;
            await HideLoading();
        }
    }
}
