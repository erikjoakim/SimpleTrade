using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrade
{
    class CCommodity
    {
        static int objectRefCounter = 0;

        public int objectID;
        public CProducer myProducer;
        public string produce;
        public DateTime onMarketAt;
        public string type = "";
        public double quantity = 0;
        public string produceName;
        public DateTime spoilTime;
        public double price;
        public void updatePrice()
        {
            price =  myProducer.getPrice(this); 
        }
        public CCommodity()
        {
            objectRefCounter++;
            objectID = objectRefCounter;
        }
    }
}
