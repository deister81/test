using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FW;
using FW.WebParts.TopChart;
using FW.WebParts.TopChart.MainContent;
using FW.Constants;



namespace TestImdb
{
    [TestClass]
    public class TestTopMovies 
    {

        private static ImdbApp webApp;
        private static TopMoviesPage mainPage;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            webApp = new ImdbApp();
            mainPage = webApp.getTopMoviesPage();

        }

        [TestMethod]
        public void TestAtLeastOneMovieIsDisplayedBySortType()
        {
            TestSort(SortType.ByImdbRating);
            TestSort(SortType.ByRanking);
            TestSort(SortType.ByReleaseDate);
            TestSort(SortType.ByNumberOfRatings);
            TestSort(SortType.ByYourRating);
        }

        [TestMethod]
        public void TestAtLeastOneMovieIsDisplayedForWesternGenre()
        {
            mainPage.LeftPanel.Genres.NavigateToGenre("Western");
            var genrepage = webApp.getTopGenrePage();            
            Assert.IsTrue(genrepage.TopList.GetMoviesCount() > 0, "Top list does not contain any movie for Genre {0}", "Western");
        }

        #region helpers
        private void TestSort(string sort)
        {
            mainPage.TopList.SortBy(sort);
            Assert.IsTrue(mainPage.TopList.GetMoviesCount() > 0, "Top list does not contain any movie sorting by {0}", sort);
        }
        #endregion helpers


        [ClassCleanup()]
        public static void ClassCleanup()
        {
            webApp.Dispose();
        }

    }
}
