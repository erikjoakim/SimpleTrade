using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrade
{
    class COfferToBuy
    {
        static int objectRefCounter = 0;

        public int objectID;
        public CConsumer myConsumer;
        public string produce;
        public double offeredPrice;
        public double quantity;
        public DateTime expires;
        public DateTime onMarketAt;

        public COfferToBuy()
        {
            objectRefCounter++;
            objectID = objectRefCounter;
        }

    }
}
