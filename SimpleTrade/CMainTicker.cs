using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrade
{
    class CMainTicker
    {
        
        static public DateTime gameDateTime = new DateTime(1300,1,1);
        static public TimeSpan elapsed = new TimeSpan(1, 0, 0, 0);

        public List<CTickerObject> tickTheseObjects = new List<CTickerObject>();
        public void tick()
        {
            foreach (CTickerObject item in tickTheseObjects)
            {
                item.tick();
                
            }
            gameDateTime += elapsed;
        }
    }
}
