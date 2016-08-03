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
    class CProducer: CTickerObject
    {
        public CMarketPlace myMarket;
        public Dictionary<int, CCommodity> itemsShipped = new Dictionary<int, CCommodity>();
        public string produceName = "Default//default";
        public double currentInStock=0;
        public double currentShipped=0;
        public double totalProduced=0;
        public double totalShipped=0;
        public double totalSold=0;
        public double totalWaste=0;
        public double totalIncome=0;
        public double totalCost = 0;
        public double totalEarnings = 0;
        public TimeSpan productionTime = new TimeSpan(30,0,0,0); //30 Days
        TimeSpan deltaTimeSinceLastProduction = new TimeSpan(0);
        public double productionQuantity = 100;
        public double shippingThreshold=90;
        public TimeSpan spoilTime = new TimeSpan(30, 0, 0, 0); //30 Days
        public double wasteThreshold = 10;
        public double price=100;
        public double productionFixedCost = 1000;
        public double productionYearlyMaintCost = 100;
        public double productionVariableLabourCost = 20;
        public double productionVariableItemCost = 20;
        private static readonly object[] EmptyArray = new object[0];

        public CProducer(TimeSpan intervall, CMarketPlace mrkt, string name, TimeSpan spltime, TimeSpan tmToPrd, int shipThrsh)
        {
            actionIntervall = intervall;
            myMarket = mrkt;
            produceName = name;
            spoilTime = spltime;
            productionTime = tmToPrd;
            shippingThreshold = shipThrsh;
            totalCost += productionFixedCost;
        }

        

        public double getPrice(CCommodity tc)
        {
            //A straight reduction in price from intro on market to spoildate           
            return price * (((tc.spoilTime - CMainTicker.gameDateTime).TotalSeconds) / ((tc.spoilTime - tc.onMarketAt).TotalSeconds));
        }

        void doProduction()
        {
            TimeSpan elapsedSinceLastProduction = CMainTicker.elapsed + deltaTimeSinceLastProduction;
            if (elapsedSinceLastProduction >= productionTime)
            {
                int batches = (int)(elapsedSinceLastProduction.TotalSeconds / productionTime.TotalSeconds);
                currentInStock += productionQuantity*batches;
                totalProduced += productionQuantity*batches;
                totalCost += productionQuantity * batches * (productionVariableItemCost + productionVariableLabourCost);
                deltaTimeSinceLastProduction = new TimeSpan(0,0,(int) (elapsedSinceLastProduction.TotalSeconds - productionTime.TotalSeconds * batches));
               
            }
            else
            {
                deltaTimeSinceLastProduction += elapsedSinceLastProduction;
            }
        }
        public bool removeFromMarket(CCommodity cm)
        {
            if (cm.price < wasteThreshold) return true; else return false;
        }

        void doUpdate()
        {
            List<int> removeCm = new List<int>();
            //Update Price on each Commodity => own function which may vary dependet on...
            foreach (CCommodity item in itemsShipped.Values)
            {
                item.price = price * (((item.spoilTime - CMainTicker.gameDateTime).TotalSeconds) / ((item.spoilTime - item.onMarketAt).TotalSeconds));
                if (removeFromMarket(item)) removeCm.Add(item.objectID);
            }
            //Remove the Commodities marked from the market and waste them
            foreach (int item in removeCm)
            {
                myMarket.removeFromMarket(item);
                totalWaste += itemsShipped[item].quantity;
                currentShipped -= itemsShipped[item].quantity;
                itemsShipped.Remove(item);
            }
            //Financials; on a quarterly basis? => to a list or similar for graphing
        }

        public void sold(CCommodity cm, double q)
        {
            if (q < cm.quantity)
            {
                totalSold += q;
                currentShipped -= q;
                totalIncome += cm.price * q;
                cm.quantity -= q;
            }
            else
            {
                totalSold += cm.quantity;
                currentShipped -= cm.quantity;
                totalIncome += cm.price * cm.quantity;
                itemsShipped.Remove(cm.objectID);
                cm.quantity = 0;
            }
        }

        void shipToMarket()
        {
            //Spawn CCommodity and ship to market
            CCommodity shp = new CCommodity();
            shp.myProducer = this;
            shp.onMarketAt = CMainTicker.gameDateTime;
            shp.price = price;
            shp.produceName = produceName;
            shp.quantity = currentInStock;
            shp.spoilTime = CMainTicker.gameDateTime.Add(spoilTime);

            currentShipped += currentInStock;
            totalShipped += currentInStock;
            currentInStock = 0;
            itemsShipped.Add(shp.objectID, shp);
            myMarket.forSale(shp);
        }

        

        public override void tick()
        {
            base.tick();

            doProduction();
            doUpdate();
            if (currentInStock > shippingThreshold) shipToMarket();
        }
    }
}
