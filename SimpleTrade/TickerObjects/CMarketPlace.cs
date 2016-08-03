using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace SimpleTrade
{
    class CMarketPlace:CTickerObject
    {
        public Dictionary<int, CCommodity> forSaleCommoditiesDict = new Dictionary<int, CCommodity>();
        public Dictionary<int, COfferToBuy> forOfferDict = new Dictionary<int, COfferToBuy>();

        public double getLowestPrice()
        {
            double lowest = 9999999999999999999999.9;
            foreach (CCommodity item in forSaleCommoditiesDict.Values)
            {
                double tmp = item.price;
                 if ( tmp < lowest)
                {
                    lowest = tmp;
                }
            }
            return lowest;
        }
        public double buy(double offeredPrice, double quantity)
        {
            CCommodity found = null;
            double tmpQ=0;
            foreach (CCommodity item in forSaleCommoditiesDict.Values)
            {
                if (offeredPrice >= item.price)
                {
                    found = item;
                    break;
                }
            }
            if (found != null)
            {
                tmpQ = found.quantity;
                if(found.quantity <= quantity) forSaleCommoditiesDict.Remove(found.objectID);
                found.myProducer.sold(found, quantity);
            }
            return Math.Min(tmpQ, quantity);
        }

        public void offerToBuy(COfferToBuy otb)
        {
            forOfferDict.Add(otb.objectID, otb);
        }

        public void forSale(CCommodity cm)
        {
            forSaleCommoditiesDict.Add(cm.objectID, cm);
        }

        public void removeFromMarket(int cmID)
        {
            forSaleCommoditiesDict.Remove(cmID);
        }

        public CCommodity buy(double offeredPrice)
        {
            CCommodity found = null;
            foreach (CCommodity item in forSaleCommoditiesDict.Values)
            {
                if (offeredPrice >= item.price)
                {
                    found = item;
                    break;
                }
            }
            if(found != null)
            {
                forSaleCommoditiesDict.Remove(found.objectID);
                found.myProducer.sold(found,found.quantity);
            }
            return found;
        }

        void sellTo(COfferToBuy otb,CCommodity cm)
        {
            if (otb.quantity >= cm.quantity)
            {
                otb.myConsumer.offerSuccess(otb, cm.quantity);
                cm.myProducer.sold(cm, cm.quantity);
            }
            else
            {
                cm.myProducer.sold(cm, otb.quantity);
                otb.myConsumer.offerSuccess(otb, otb.quantity);
                
            }
        }
        void matchOffers()
        {
            List<int> cmRemove = new List<int>();
            List<int> otbRemove = new List<int>();
            foreach (COfferToBuy otb in forOfferDict.Values)
            {
                foreach (CCommodity cm in forSaleCommoditiesDict.Values)
                {
                    if (otb.produce == cm.produce)
                    {
                        if (otb.offeredPrice >= cm.price)
                        {
                            //We got a sale!
                            sellTo(otb, cm);
                            if (cm.quantity == 0) cmRemove.Add(cm.objectID);
                            if (otb.quantity == 0)
                            {
                                otbRemove.Add(otb.objectID);
                                break;
                            }
                        }
                    }
                }
            }
            foreach (int item in cmRemove)
            {
                forSaleCommoditiesDict.Remove(item);
            }
            foreach (int item in otbRemove)
            {
                forOfferDict.Remove(item);
            }
        }

        public override void tick()
        {
            matchOffers();
        }

        
    }
}
