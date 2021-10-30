using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Windows.Forms;
using HtmlAgilityPack;


namespace BballFantasyScheduleBuilder
{
    public class Team
    {
        public string name;
        public string abbrev;
        public string url;
        //int weekNum , int numGames
        public Dictionary<int, int> games = new Dictionary<int, int>();
        //list of weeks. a week contains startDate and endDate;


        public Team(string teamname, string webAbbrev, List<Week> wklist)
        {
            name = teamname;
            abbrev = webAbbrev;
            /*Be sure to change the year in the url for the season that you are in
             ex: 21-22 season should have the year 2022*/
            url = string.Format(@"https://www.basketball-reference.com/teams/{0}/2022_games.html", abbrev);
            populateGames(wklist);
        }

        void populateGames(List<Week> weeklist)
        {
            var web = new HtmlWeb(); //htmlagilitypack object
            var doc = web.Load(url);

            /*selects node with the id 'games'
              when running next year make sure the games table has id="games" */
            var tableNode = doc.DocumentNode.SelectSingleNode("//*[@id='games']"); //selects the table element with id 'games'
            //doc.Dispose();
            var gameNodes = tableNode.SelectNodes("//tr/td[@data-stat='date_game']"); //selects attribute with data-stat="date_game" the nodes with the date have <td class="left " data-stat="date_game" csk="2019-10-23" >
            List<string> errorNodes = new List<string>();
            /*Make sure to initialize games with the week youre starting on. Ex: for 2020-2021 season, fantasy started on week 2, so games[2] = 0*/
            games[1] = 0;//initialize it so you dont try to pop first element in weeklist 
            int wkindex = 0;
            foreach (HtmlNode node in gameNodes)
            {
                string[] dateSplit = node.GetAttributeValue("csk", "default").Split('-'); //returs ['yyyy','mm','dd']
                try
                {
                    DateTime gamedate = new DateTime(Convert.ToInt16(dateSplit[0]), Convert.ToInt16(dateSplit[1]), Convert.ToInt16(dateSplit[2]));

                    if (gamedate <= weeklist[wkindex].endDate)
                    {
                        games[weeklist[wkindex].weekNum] = games[weeklist[wkindex].weekNum] + 1; //adding another game that that weeks (games[weeknum]) number of games
                    }
                    else
                    {
                        wkindex = wkindex + 1;
                        games[weeklist[wkindex].weekNum] = 1;
                    }

                }
                catch (Exception ex)
                {
                    if (wkindex < weeklist.Count) // the error is becuase its counting games past 23 weeks
                    {
                        errorNodes.Add(string.Format(">{0}{1}>{2}", node.InnerText, Environment.NewLine, ex)); //if error getting date from node add it to the list
                    }
                }
            }

            if (errorNodes.Count > 0)
            {
                MessageBox.Show(string.Format("There were {0} nodes with errors",errorNodes.Count));
            }
        }
            
    }
}