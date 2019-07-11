using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToTwitter;

namespace TwitterBot
{
    public static class TwitterStuff
    {
        static SingleUserAuthorizer auth;
        static TwitterContext twitterContext;
        static TwitterStuff()
        {
            auth = Authenticate();
            twitterContext = new TwitterContext(auth);
        }
        public static async Task<List<Status>> GetTwitterData(string query, int count, ulong? maxID, ulong? sinceID)
        {
            Console.WriteLine("Querying tweets:");
            int tweetsPerQuery = 100;
            List<Status> searchQuery;
            var combinedSearchResults = new List<Status>();
            do
            {
                Console.CursorLeft = 0;
                if ((count - combinedSearchResults.Count) < 100) { tweetsPerQuery = (count - combinedSearchResults.Count); }
                searchQuery =
                    await
                    (from search in twitterContext.Search
                     where search.Type == SearchType.Search &&
                     search.IncludeEntities == true &&
                     search.ResultType == ResultType.Recent &&
                     search.TweetMode == TweetMode.Extended &&
                     search.Query == query &&
                     search.Count == tweetsPerQuery &&
                     search.MaxID == (maxID ?? ulong.MaxValue) &&
                     search.SinceID == (sinceID ?? 1)
                     select search.Statuses).SingleOrDefaultAsync();
                maxID = searchQuery.Min(status => status.StatusID) - 1;
                combinedSearchResults.AddRange(searchQuery);
                Console.Write("Tweets recieved: {0}", combinedSearchResults.Count);
            } while (searchQuery.Any() && combinedSearchResults.Count < count);
            Console.WriteLine();
            return combinedSearchResults;
        }
        public static void GetRawData(string query)
        {
            string unencodedStatus = query;
            string encodedStatus = Uri.EscapeDataString(unencodedStatus);
            string queryString = "search/tweets.json?q=" + encodedStatus;

            var rawResult =
                (from raw in twitterContext.RawQuery
                 where raw.QueryString == queryString
                 select raw)
                .SingleOrDefaultAsync();
            
            if (rawResult != null)
                Console.WriteLine(
                    "Response from Twitter: \n\n" + rawResult.Result.Response);
        }
        
        public static SingleUserAuthorizer Authenticate()
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"],
                    AccessToken = ConfigurationManager.AppSettings["accessToken"],
                    AccessTokenSecret = ConfigurationManager.AppSettings["accessTokenSecret"]
                }
            };
            return auth;
        }
    }
}
