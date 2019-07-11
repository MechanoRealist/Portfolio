using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LinqToTwitter;

namespace TwitterBot
{
    public static class Controlpanel
    {
        
        static string searchQuery;
        static int numberOfTweetsToFetch;
        static int insertSize;
        static ulong? maxID;
        static ulong? sinceID;
        public static void Init()
        {
            numberOfTweetsToFetch = 10000;
            searchQuery = "#dkpol";
            insertSize = 500;
        }
        public static void AssembleDataset(Database database)
        {
            int marker = 0;
            do
            {
                if ((numberOfTweetsToFetch - marker) < insertSize) { insertSize = (numberOfTweetsToFetch - marker); }
                Task<List<Status>> statuses = TwitterStuff.GetTwitterData(searchQuery, insertSize, maxID, sinceID);
                statuses.Wait();
                var listOfTweets = statuses.Result;
                maxID = listOfTweets.Min(status => status.StatusID) - 1;
                try
                {
                    database.Insert(listOfTweets);
                    marker += listOfTweets.Count;
                }
                catch
                {
                    Console.WriteLine("SQL INSERT failed. Try again? Press any key...");
                    Console.ReadKey();
                }

            } while (marker < numberOfTweetsToFetch);
        }

        public static void StartAnalysis()
        {
            
            Console.ReadLine();
        }
    }
}
/*foreach (var tweet in listOfTweets)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var ent in tweet.Entities.HashTagEntities)
                {
                    builder.Append(ent.Text).Append(",");
                }
                Console.WriteLine("\n User: {0} ({1})\n StatusID: {2}\n Hashtags: {3}\n Text: {4}\n Media Entities: {5}\n URL Entities: {6}\n Reply to StatusID: {7}\n Reply to UserID: {8}",
                                    tweet.User.ScreenNameResponse, tweet.User.UserIDResponse, tweet.StatusID, builder.ToString(), tweet.Text ?? tweet.FullText,
                                    tweet.Entities.MediaEntities.Count, tweet.Entities.UrlEntities.Count, tweet.InReplyToStatusID, tweet.InReplyToUserID);
                
            }
*/