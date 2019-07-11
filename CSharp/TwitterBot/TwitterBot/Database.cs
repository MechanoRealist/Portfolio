using System;
using System.Collections.Generic;
using System.Text;
using LinqToTwitter;
using MySql.Data.MySqlClient;

namespace TwitterBot
{
    public class Database
    {
        string connStr = "server=localhost;user=root;database=twitter;port=3306;password=asdf";
        MySqlConnection dbConn;
        public Database()
        {
            dbConn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                dbConn.Open();
                MySqlCommand cmd = new MySqlCommand("USE twitter", dbConn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void Insert(Status tweet)
        {
            //int tweetID, int userID, string text, DateTime datePosted, int favs, int retweetCount, string hashtags, int inReplyToUserID, int inReplyToTweetID, DateTime dateRecorded, int numberOfMedia, int numberOfURL
            StringBuilder hashtagStr = new StringBuilder();
            string escapedText = (tweet.Text ?? tweet.FullText).Replace("'", "\\'");
            ulong userID = ulong.Parse(tweet.User.UserIDResponse);
            foreach (var ent in tweet.Entities.HashTagEntities)
            {
                hashtagStr.Append(ent.Text).Append(",");
            }
            DateTime dateRecorded = DateTime.Now;
            string cmdSQLStr = string.Format("INSERT INTO tweets VALUES ({0},{1},'{2}','{3}',{4},{5},'{6}',{7},{8},'{9}',{10},{11}) ON DUPLICATE KEY UPDATE userID={1}, text='{2}', datePosted='{3}', favs={4}, retweetCount={5}, hashtags='{6}', inReplyToUserID={7}, inReplyToTweetID={8}, dateRecorded='{9}', numberOfMedia={10}, numberOfURL={11};",
                tweet.StatusID, userID, escapedText, tweet.CreatedAt.ToString("s"), tweet.FavoriteCount, tweet.RetweetCount, hashtagStr.ToString(), tweet.InReplyToUserID, tweet.InReplyToStatusID, dateRecorded, tweet.Entities.MediaEntities.Count, tweet.Entities.UrlEntities.Count);
            MySqlCommand cmd = new MySqlCommand(cmdSQLStr, dbConn);
            cmd.ExecuteNonQuery();
        }
        public void Insert(List<Status> tweets)
        {
            DateTime dateRecorded;
            StringBuilder cmdSQLStr = new StringBuilder();
            cmdSQLStr.Append("INSERT INTO tweets VALUES ");
            foreach (var tweet in tweets)
            {
                string escapedText = (tweet.Text ?? tweet.FullText).Replace("'", "\\'");
                ulong userID = ulong.Parse(tweet.User.UserIDResponse);
                StringBuilder hashtagStr = new StringBuilder();
                foreach (var ent in tweet.Entities.HashTagEntities)
                {
                    hashtagStr.Append(ent.Text).Append(",");
                }
                dateRecorded = DateTime.Now;
                cmdSQLStr.AppendFormat("({0},{1},'{2}','{3}',{4},{5},'{6}',{7},{8},'{9}',{10},{11}),",
                    tweet.StatusID, userID, escapedText, tweet.CreatedAt.ToString("s"), tweet.FavoriteCount, tweet.RetweetCount, hashtagStr.ToString(), tweet.InReplyToUserID, tweet.InReplyToStatusID, dateRecorded.ToString("s"), tweet.Entities.MediaEntities.Count, tweet.Entities.UrlEntities.Count);
            }
            cmdSQLStr.Length--;
            cmdSQLStr.Append(" ON DUPLICATE KEY UPDATE userID=VALUES(userID), text=VALUES(text), datePosted=VALUES(datePosted), favs=VALUES(favs), retweetCount=VALUES(retweetCount), hashtags=VALUES(hashtags), inReplyToUserID=VALUES(inReplyToUserID), inReplyToTweetID=VALUES(inReplyToTweetID), dateRecorded=VALUES(dateRecorded), numberOfMedia=VALUES(numberOfMedia), numberOfURL=VALUES(numberOfURL);");
            
            MySqlCommand cmd = new MySqlCommand(cmdSQLStr.ToString(), dbConn);
            Encoding.Unicode.GetByteCount(cmdSQLStr.ToString());
            cmd.ExecuteNonQuery();
        }
        public void Query()
        {

        }
        public int GetMaxQuerySize()
        {
            MySqlCommand cmd = new MySqlCommand("SHOW VARIABLES LIKE 'max_allowed_packet';", dbConn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            int size = int.Parse((string)rdr[1]);
            return size;
        }
        ~Database()
        {
            dbConn.Close();
        }
    }
}
