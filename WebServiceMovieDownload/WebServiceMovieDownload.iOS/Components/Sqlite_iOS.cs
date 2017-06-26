using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using WebServiceMovieDownload.Interfaces;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebServiceMovieDownload.iOS.Components.Sqlite_iOS))]
namespace WebServiceMovieDownload.iOS.Components
{
    public class Sqlite_iOS : ISqlite
    {
        public Sqlite_iOS()
        {
        }

        #region ISQLite Implementation
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "WebSMovieD.db";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
        #endregion
    }

}