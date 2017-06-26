using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebServiceMovieDownload.BasePageViewModels;
using WebServiceMovieDownload.Globals;
using WebServiceMovieDownload.Models;
using WebServiceMovieDownload.Pages;
using Xamarin.Forms;

namespace WebServiceMovieDownload.PageViewModels
{
    public class MainPageViewModel : BasePageViewModel
    {
        private ObservableCollection<MovieModel> _topRatedMovies;
        private ObservableCollection<MovieModel> _nowPlayingMovies;
        private ObservableCollection<MovieModel> _popularMovies;

        public ObservableCollection<MovieModel> TopRatedMovies
        {
            get
            {
                return _topRatedMovies;
            }
            set
            {
                _topRatedMovies = value;
                OnPropertyChanged("TopRatedMovies");
            }
        }
        public ObservableCollection<MovieModel> PopularMovies
        {
            get
            {
                return _popularMovies;
            }
            set
            {
                _popularMovies = value;
                OnPropertyChanged("PopularMovies");
            }
        }
        public ObservableCollection<MovieModel> NowPlayingMovies
        {
            get
            {
                return _nowPlayingMovies;
            }
            set
            {
                _nowPlayingMovies = value;
                OnPropertyChanged("NowPlayingMovies");
            }
        }

        public ICommand FavoritesCommand { get; set; }
        public ICommand RefreshNowPlayingCommand { get; set; }
        public ICommand RefreshTopRatedCommand { get; set; }
        public ICommand RefreshPopularCommand { get; set; }

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

        public MainPageViewModel()
        {
            this.Title = "Main";
            this.FavoritesCommand = new Command(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new FavoritesListViewPage());
                });
            });
            this.RefreshNowPlayingCommand = new Command(async () =>
            {
                IsRefreshing = true;
                await RefreshNowPlayingMovies();
                IsRefreshing = false;
            });
            this.RefreshTopRatedCommand = new Command(async () =>
            {
                IsRefreshing = true;
                await RefreshTopRatedMovies();
                IsRefreshing = false;
            });
            this.RefreshPopularCommand = new Command(async () =>
            {
                IsRefreshing = true;
                await RefreshPopularMovies();
                IsRefreshing = false;
            });
            GetNowPlayingMovies();
            GetTopRatedMovies();
            GetPopularMovies();
        }

        public void OnSelectedItem(MovieModel model)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new MovieDetailPage(model));
            });

        }

        private async void GetPopularMovies()
        {            
            // get movies
            var model = await this.WebService.GetMovies("popular");
            UpdateMovies(model,"Popular");
            await HideLoading();
        }
        private async void GetNowPlayingMovies()
        {
            await ShowLoading();

            // get movies
            var model = await this.WebService.GetMovies("now_playing");
            UpdateMovies(model, "Now Playing");

        }
        private async void GetTopRatedMovies()
        {
            // get movies
            var model = await this.WebService.GetMovies("top_rated");
            UpdateMovies(model,"Top Rated");

        }

        private void UpdateMovies(MovieListResponseModel model, string option)
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
            switch(option)
            {
                case "Popular":
                    PopularMovies = movieItems;
                    break;
                case "Now Playing":
                    NowPlayingMovies = movieItems;
                    break;
                case "Top Rated":
                    TopRatedMovies = movieItems;
                    break;
            }
        }

        private async Task RefreshNowPlayingMovies()
        {
            // get movies
            GetNowPlayingMovies();
        }
        private async Task RefreshTopRatedMovies()
        {
            // get movies
            GetTopRatedMovies();
        }
        private async Task RefreshPopularMovies()
        {
            // get movies
            GetPopularMovies();
        }

    }
}
