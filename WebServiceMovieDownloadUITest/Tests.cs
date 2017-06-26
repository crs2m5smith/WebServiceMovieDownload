using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace WebServiceMovieDownloadUITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        static readonly Func<AppQuery, AppQuery> NowPlayingButton = c => c.Marked("NowPlayingButton");
        static readonly Func<AppQuery, AppQuery> TopRatedButton = c => c.Marked("TopRatedButton");
        static readonly Func<AppQuery, AppQuery> PopularButton = c => c.Marked("PopularButton");
        static readonly Func<AppQuery, AppQuery> FavoritesButton = c => c.Marked("FavoritesButton");

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }


    }
}

