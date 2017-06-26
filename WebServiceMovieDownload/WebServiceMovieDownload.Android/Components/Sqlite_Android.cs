using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WebServiceMovieDownload.Interfaces;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(WebServiceMovieDownload.Droid.Components.Sqlite_Android))]

namespace WebServiceMovieDownload.Droid.Components
{
    public class Sqlite_Android : ISqlite
    {
        public Sqlite_Android()
        {
        }

        #region ISqlite Implementation
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "WebSMovieD.db";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
        #endregion
    }

}