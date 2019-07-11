-- See all databases in MySQL
select schema_name from information_schema.schemata;

INSERT INTO tweets VALUES (1237,4321,'FIrst replace entry',NULL,28,67,'asdf,qwer,',43215678,NULL,'2018-06-13 12:55:00',0,1),(1235,4321,'Second replace entry',NULL,30,67,'asdf,qwer,tyui,',43215678,NULL,'2018-06-13 12:55:00',5,1),(1238,4321,'New entry!!',NULL,28,67,'asdf,qwer,',43215678,NULL,'2018-06-13 12:55:00',0,1)
ON DUPLICATE KEY UPDATE userID=VALUES(userID), text=VALUES(text), datePosted=VALUES(datePosted), favs=VALUES(favs), retweetCount=VALUES(retweetCount), hashtags=VALUES(hashtags), inReplyToUserID=VALUES(inReplyToUserID), inReplyToTweetID=VALUES(inReplyToTweetID), dateRecorded=VALUES(dateRecorded), numberOfMedia=VALUES(numberOfMedia), numberOfURL=VALUES(numberOfURL);
