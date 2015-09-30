using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.Constants
{
    public static class SortType
    {
        public static string ByRanking { get { return "Ranking"; } }
        public static string ByImdbRating { get { return "IMDb Rating"; } }
        public static string ByReleaseDate { get { return "Release Date"; } }
        public static string ByNumberOfRatings { get { return "Number of Ratings"; } }
        public static string ByYourRating { get { return "Your Rating"; } }
    }

}
