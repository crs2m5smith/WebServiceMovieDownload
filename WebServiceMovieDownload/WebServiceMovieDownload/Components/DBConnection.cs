using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceMovieDownload.Interfaces;
using WebServiceMovieDownload.Models;
using WebServiceMovieDownload.Utilities;
using Xamarin.Forms;

namespace WebServiceMovieDownload.Components
{
    public class DBConnection
    {
        private string apiKey = "<EnterApiKey>";
        private static DBConnection _db;
        public static DBConnection db
        {
            get
            {
                if (_db == null)
                    _db = new DBConnection();

                return _db;
            }
        }

        private SQLiteConnection connection;

        object locker = new object();

        private DBConnection()
        {
            connection = DependencyService.Get<ISqlite>().GetConnection();
            InitTables();
            InitSetup();


        }
        public DBConnection(SQLiteConnection connection)
        {
            this.connection = connection;
        }


        private void InitTables()
        {
            connection.CreateTable<FavoriteModel>();
            connection.CreateTable<AccountModel>();
        }
        public void InitSetup()
        {
            lock (locker)
            {
                var accountTable = connection.Table<AccountModel>();

                if (accountTable.Count() == 0)
                {
                    var model = new AccountModel
                    {
                        ApiKey = apiKey,
                        Date = DateTime.Now,
                          
                    };
                    connection.Insert(model, typeof(AccountModel));
                    
                }

            }
        }
        public AccountModel GetAccount()
        {
            lock(locker)
            {
                TableQuery<AccountModel> account = connection.Table<AccountModel>();
                return account?.FirstOrDefault();
            }
        }
        public List<FavoriteModel> GetFavorites()
        {
            lock (locker)
            {
                TableQuery<FavoriteModel> favorites = connection.Table<FavoriteModel>();
                return favorites.ToList();
            }
        }


        public FavoriteModel GetFavoriteById(int id)
        {
            lock (locker)
            {
                TableQuery<FavoriteModel> favorites = connection.Table<FavoriteModel>().Where(a=>a.MovieId == id);
                return favorites?.FirstOrDefault();
            }
        }
        public int SaveFavorite(FavoriteModel favorite)
        {
            lock (locker)
            {
                TableQuery<FavoriteModel> favorites = connection.Table<FavoriteModel>().Where(g => g.Id == favorite.Id);

                //check for existing favorite
                FavoriteModel existingFavorite = favorites.Count() == 0 ? null : favorites.First();

                if (existingFavorite != null)
                {
                    // update
                    return connection.Update(favorite, typeof(FavoriteModel));
                }
                else
                {
                    // new and save
                    return connection.Insert(favorite, typeof(FavoriteModel));
                }
            }
        }
        public int RemoveFavorite(FavoriteModel favorite)
        {
            lock (locker)
            {
                // delete
                return connection.Delete(favorite);
             
            }
        }

    }
}
