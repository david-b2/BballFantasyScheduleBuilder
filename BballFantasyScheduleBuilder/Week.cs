using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BballFantasyScheduleBuilder
{
    
    public class Week
    {
        public DateTime startDate;
        public DateTime endDate;
        public int weekNum;

        public Week(int weeknum, DateTime start, DateTime end)
        {
            startDate = start;
            endDate = end;
            weekNum = weeknum;
        }
    }
}
