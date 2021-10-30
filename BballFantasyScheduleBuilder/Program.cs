using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

/*to update:
 * update Team class url with current years link
 * update populateWeeks method with correct amount of weeks, and correct dates
     */

namespace BballFantasyScheduleBuilder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static List<Team> Teams;
        //public static List<Team2> Teams2;

        /*
         *MAY NEED TO RUN THIS TWICE WITH HALF OF THE TEAMS IN POPULATEGAMES() COMMENTED OUT EACH TIME. 
         * IF NOT THE HTML WEB CONNECTION COULD TIME OUT ABOUT
         * A LITTLE OVER HALF WAY THROUGH THE TEAMS. make sure to change the file name variable below
         * before running a second time
         */
        public static string filename = @"C:\Users\David\Documents\Fantasy Basketball\GAMES.xml";

        static void Main()
        {
            //Teams: list of teams
            //weeklist: (static from class Weeklist) list of Week objects.
            Teams = new List<Team>();
            //Teams2 = new List<Team2>();
            List<Week> weeklist = populateWeeks(); //must populate weeks before teams; teams use weeks to get game counts
            populateTeams(weeklist);

            //populateTeams2(weeklist);

            createXML();


            MessageBox.Show("finished");

        }

        public static List<Week> populateWeeks()
        {
            List<Week> weeklist = new List<Week>();
            //add new week to list of weeks 
            //                           weeknum              startdate                     enddate
           /* weeklist.Add(new Week(01, new DateTime(2019, 10, 22), new DateTime(2019, 10, 27)));*/

            weeklist.Add(new Week(02, new DateTime(2020, 12, 28), new DateTime(2021, 01, 03)));
            weeklist.Add(new Week(03, new DateTime(2021, 01, 04), new DateTime(2021, 01, 10)));
            weeklist.Add(new Week(04, new DateTime(2021, 01, 11), new DateTime(2021, 01, 17)));
            weeklist.Add(new Week(05, new DateTime(2021, 01, 18), new DateTime(2021, 01, 24)));
            weeklist.Add(new Week(06, new DateTime(2021, 01, 25), new DateTime(2021, 01, 31)));
            weeklist.Add(new Week(07, new DateTime(2021, 02, 01), new DateTime(2021, 02, 07)));
            weeklist.Add(new Week(08, new DateTime(2021, 02, 08), new DateTime(2021, 02, 14)));
            weeklist.Add(new Week(09, new DateTime(2021, 02, 15), new DateTime(2021, 02, 21)));
            weeklist.Add(new Week(10, new DateTime(2021, 02, 22), new DateTime(2021, 02, 28)));
            weeklist.Add(new Week(11, new DateTime(2021, 03, 01), new DateTime(2021, 03, 14)));
            weeklist.Add(new Week(12, new DateTime(2021, 03, 15), new DateTime(2021, 03, 21)));
            weeklist.Add(new Week(13, new DateTime(2021, 03, 22), new DateTime(2021, 03, 28)));
            weeklist.Add(new Week(14, new DateTime(2021, 03, 29), new DateTime(2021, 04, 04)));
            weeklist.Add(new Week(15, new DateTime(2021, 04, 05), new DateTime(2021, 04, 11)));
            weeklist.Add(new Week(16, new DateTime(2021, 04, 12), new DateTime(2021, 04, 18)));
            weeklist.Add(new Week(17, new DateTime(2021, 04, 19), new DateTime(2021, 04, 25)));
            weeklist.Add(new Week(18, new DateTime(2021, 04, 26), new DateTime(2021, 05, 02)));

            /*weeklist.Add(new Week(11, new DateTime(2021, 03, 01), new DateTime(2021, 03, 07)));
            weeklist.Add(new Week(12, new DateTime(2021, 03, 08), new DateTime(2021, 03, 14)));
            weeklist.Add(new Week(13, new DateTime(2021, 03, 15), new DateTime(2021, 03, 21)));
            weeklist.Add(new Week(14, new DateTime(2021, 03, 22), new DateTime(2021, 03, 28)));
            weeklist.Add(new Week(15, new DateTime(2021, 03, 29), new DateTime(2021, 04, 04)));
            weeklist.Add(new Week(16, new DateTime(2020, 04, 05), new DateTime(2020, 04, 11)));
            weeklist.Add(new Week(17, new DateTime(2020, 04, 12), new DateTime(2020, 04, 18)));
            weeklist.Add(new Week(18, new DateTime(2020, 04, 19), new DateTime(2020, 04, 25)));*/


            /*weeklist.Add(new Week(19, new DateTime(2020, 02, 24), new DateTime(2020, 03, 01)));
            weeklist.Add(new Week(20, new DateTime(2020, 03, 02), new DateTime(2020, 03, 08)));
            weeklist.Add(new Week(21, new DateTime(2020, 03, 09), new DateTime(2020, 03, 15)));
            weeklist.Add(new Week(22, new DateTime(2020, 03, 16), new DateTime(2020, 03, 22)));
            weeklist.Add(new Week(23, new DateTime(2020, 03, 23), new DateTime(2020, 03, 29)));*/

            return weeklist;
        }

        public static void populateTeams(List<Week> weeklist)
        {
            //create list of teams  
            Teams.Add(new Team("76ers", "PHI", weeklist));
            Teams.Add(new Team("Bucks", "MIL", weeklist));
            Teams.Add(new Team("Bulls", "CHI", weeklist));
            Teams.Add(new Team("Cavaliers", "CLE", weeklist));
            Teams.Add(new Team("Celtics", "BOS", weeklist));
            Teams.Add(new Team("Clippers", "LAC", weeklist));
            Teams.Add(new Team("Grizzlies", "MEM", weeklist));
            Teams.Add(new Team("Hawks", "ATL", weeklist));
            Teams.Add(new Team("Heat", "MIA", weeklist));
            Teams.Add(new Team("Hornets", "CHO", weeklist));
            Teams.Add(new Team("Jazz", "UTA", weeklist));
            Teams.Add(new Team("Kings", "SAC", weeklist));
            Teams.Add(new Team("Knicks", "NYK", weeklist));
            Teams.Add(new Team("Lakers", "LAL", weeklist));
            Teams.Add(new Team("Magic", "ORL", weeklist));
            Teams.Add(new Team("Mavericks", "DAL", weeklist));
            Teams.Add(new Team("Nets", "BRK", weeklist));
            Teams.Add(new Team("Nuggets", "DEN", weeklist));
            Teams.Add(new Team("Pacers", "IND", weeklist));
            Teams.Add(new Team("Pelicans", "NOP", weeklist));
            Teams.Add(new Team("Pistons", "DET", weeklist));
            Teams.Add(new Team("Raptors", "TOR", weeklist));
            Teams.Add(new Team("Rockets", "HOU", weeklist));
            Teams.Add(new Team("Spurs", "SAS", weeklist));
            Teams.Add(new Team("Suns", "PHO", weeklist));
            Teams.Add(new Team("Thunder", "OKC", weeklist));
            Teams.Add(new Team("Timberwolves", "MIN", weeklist));
            Teams.Add(new Team("Trail Blazers", "POR", weeklist));
            Teams.Add(new Team("Warriors", "GSW", weeklist));
            Teams.Add(new Team("Wizards", "WAS", weeklist));
            //Teams.Add(new Team("Bulls", "CHI", weeklist));
        }

        public static void createXML()
        {
            XmlTextWriter writer = new XmlTextWriter(filename, System.Text.Encoding.Unicode);
            //XmlTextWriter writer = XmlWriter.Create("games.xml", System.Text.Encoding.Unicode);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Schedule");
            foreach (Team team in Teams)
            {
                writer.WriteStartElement("Team");
                
                int strength = team.games[team.games.Count - 1] + team.games[team.games.Count - 2]; // sum of last two games in playoffs
                writer.WriteAttributeString("playoff-strength", strength.ToString());
                writer.WriteAttributeString("name", team.name);
                foreach (KeyValuePair<int, int> entry in team.games)
                {
                    writer.WriteStartElement("week");
                    writer.WriteAttributeString("wknum", entry.Key.ToString());
                    writer.WriteAttributeString("games", entry.Value.ToString());
                    writer.WriteEndElement(); //close week
                }
                writer.WriteEndElement();//close team
            }
            writer.WriteEndElement(); //close schedule
            writer.Flush();
            //writer.WriteEndDocument();//close document
        }

    }
}
