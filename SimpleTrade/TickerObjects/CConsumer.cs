using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrade
{
    class CConsumer: CTickerObject
    {
        CMarketPlace myMarket;
        Dictionary<int, COfferToBuy> currentOffers = new Dictionary<int, COfferToBuy>();
        DateTime lastPurchase;
        public TimeSpan timePerDollarPriceIncrease = new TimeSpan(1,0,0);
        public TimeSpan timeToConsume = new TimeSpan(1, 0, 0, 0);
        public double commodityInStore = 0;
        public double purchaseQuantity = 85;
        public double commodityThreshold = 100;


        public CConsumer(CMarketPlace mrkt)
        {
            myMarket = mrkt;
            lastPurchase = CMainTicker.gameDateTime;
        }
        public CConsumer(int pQ, CMarketPlace mrkt)
        {
            myMarket = mrkt;
            purchaseQuantity = pQ;
            lastPurchase = CMainTicker.gameDateTime;
        }
        public CConsumer(TimeSpan interval, CMarketPlace mrkt)
        {
            myMarket = mrkt;
            actionIntervall = interval;
            lastPurchase = CMainTicker.gameDateTime;
        }

        public virtual double offeredPrice(TimeSpan elapsed)
        {
            return (elapsed.TotalSeconds / timePerDollarPriceIncrease.TotalSeconds);
        }
        public virtual double offeredPrice()
        {
            return ((CMainTicker.gameDateTime - lastPurchase).TotalSeconds / timePerDollarPriceIncrease.TotalSeconds);
        }

        void eatCommodity()
        {
            int eaten = (int) (CMainTicker.elapsed.TotalSeconds / timeToConsume.TotalSeconds);
            commodityInStore = Math.Min(0, commodityInStore - eaten);
        }

        public void offerSuccess(COfferToBuy otb, double q)
        {
            commodityInStore += q;
            otb.quantity -= q;
            currentOffers.Remove(otb.objectID);
            lastPurchase = CMainTicker.gameDateTime;
        }

        public void makeOfferToBuy()
        {
            COfferToBuy otb = new COfferToBuy();
            otb.myConsumer = this;
            otb.onMarketAt = CMainTicker.gameDateTime;
            otb.offeredPrice = offeredPrice();
            otb.quantity = purchaseQuantity;
            otb.expires = CMainTicker.gameDateTime.AddDays(5);
            currentOffers.Add(otb.objectID, otb);
            myMarket.offerToBuy(otb);
        }

        public override void tick()
        {
            base.tick();
            eatCommodity();
            if (commodityInStore < commodityThreshold)
            {
                makeOfferToBuy();
            }
        }
    }
}
