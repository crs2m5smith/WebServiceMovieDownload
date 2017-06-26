using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebServiceMovieDownload.BasePageViewModels;
using WebServiceMovieDownload.Components;
using WebServiceMovieDownload.Globals;
using WebServiceMovieDownload.Models;
using WebServiceMovieDownload.Pages;
using WebServiceMovieDownload.Utilities;
using Xamarin.Forms;

namespace WebServiceMovieDownload.PageViewModels
{
    public class MovieDetailPageViewModel : BasePageViewModel
    {
        private static string RemoveFavorite = "Remove From Favorites";
        private static string SaveFavorite = "Save To Favorites";
        private string _favorite;
        private MovieModel _movie;

        private ObservableCollection<MovieModel> _similarMovies;

        public ObservableCollection<MovieModel> SimilarMovies
        {
            get
            {
                return _similarMovies;
            }
            set
            {
                _similarMovies = value;
                OnPropertyChanged("SimilarMovies");
            }
        }
        public ICommand RefreshSimilarCommand { get; set; }
        public ICommand FavoriteCommand { set; get; }
        public MovieModel Movie
        {
            get { return _movie; }
            set
            {
                if (_movie != value)
                {
                    _movie = value;
                    OnPropertyChanged("Movie");
                }
            }
        }
        public string Favorite
        {
            get { return _favorite; }
            set
            {
                if (_favorite != value)
                {
                    _favorite = value;
                    OnPropertyChanged("Favorite");
                }
            }
        }

        public MovieModel _selectedItem;
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
        public MovieDetailPageViewModel() : this(null) { }

        public void UpdateFavoriteText()
        {
            var favorite = DBConnection.db.GetFavoriteById(_movie.Id);
            if (favorite != null)
                _favorite = RemoveFavorite;
            else
                _favorite = SaveFavorite;
        }

        public void OnSelectedItem(MovieModel model)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new MovieDetailPage(model));
            });

        }
        public MovieDetailPageViewModel(MovieModel movie)
        {
            this._movie = movie;

            movie.ReleaseDate = "Release Date: " + movie.ReleaseDate;
            UpdateFavoriteText();
            this.RefreshSimilarCommand = new Command(async () =>
            {
                IsRefreshing = true;
                await RefreshSimilarMovies();
                IsRefreshing = false;
            });
            this.FavoriteCommand = new Command(() =>
            {
                OnfavoriteTapped();

            });
            GetSimilarMovies();
        }

        public void OnfavoriteTapped()
        {
            var favorite = DBConnection.db.GetFavoriteById(_movie.Id);
            if (favorite == null)
            {
                var model = new FavoriteModel()
                {
                    MovieId = _movie.Id,
                    Date = DateTime.Now,
                    PosterPath = _movie.PosterPath,
                    Title = _movie.Title,
                    Overview = _movie.Overview
                };
                DBConnection.db.SaveFavorite(model);
                _favorite = RemoveFavorite;
                ToastMessage.ShortMessage("Favorite Added...");

            }
            else
            {
                DBConnection.db.RemoveFavorite(favorite);
                _favorite = SaveFavorite;
                ToastMessage.ShortMessage("Favorite Removed...");

            }
            OnPropertyChanged("Favorite");

        }

        private async Task RefreshSimilarMovies()
        {
            // get movies
            GetSimilarMovies();
        }
        private async void GetSimilarMovies()
        {
            await ShowLoading();

            // get movies
            var model = await this.WebService.GetSimilars(_movie.Id);
            UpdateMovies(model);
            await HideLoading();

        }
        private void UpdateMovies(MovieListResponseModel model)
        {
            var movieItems = new ObservableCollection<MovieModel>();

            foreach (var result in model?.Results)
            {
                var movie = new MovieModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    ImageSource = (!string.IsNullOrEmpty(result.PosterPath) ? ImageSource.FromUri(new Uri(string.Format(WebServiceEndPoints._posterPoint, result.PosterPath))) : ImageSource.FromFile("icon.png")),
                    Overview = result.Overview,
                    PosterPath = result.PosterPath
                };
                movieItems.Add(movie);

            }

            SimilarMovies = movieItems;

        }
    }
}
