using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace SimpleTrade
{
    class DateAndValue
    {
        public DateTime thisDate { get; set; }
        public double value { get; set; }
        public DateAndValue(DateTime dt, double db)
        {
            thisDate = dt;
            value = db;
        }
    }
    class CTickerObject
    { 
        public Dictionary<string, List<DateAndValue>> collectDataDict = new Dictionary<string, List<DateAndValue>>();
        public static Dictionary<string, List<string>> hiddenFields = new Dictionary<string, List<string>>();

        public TimeSpan actionIntervall;
        public string ObjectName="";
        public int ObjectID=0;
        public static int instanceCount;
        
        public CTickerObject()
        {
            instanceCount++;
            ObjectID = instanceCount;
        }

        public static void hideField(Type objType, string fieldName)
        {
           
            if (hiddenFields.ContainsKey(objType.ToString()))
            {
                if (!hiddenFields[objType.ToString()].Contains(fieldName)) hiddenFields[objType.ToString()].Add(fieldName);
            }
            else
            {
                List<string> tmpl = new List<string>();
                tmpl.Add(fieldName);
                hiddenFields.Add(objType.ToString(), tmpl);
            }
        }

        public static void showField(string objType, string fieldName)
        {
            if (hiddenFields.ContainsKey(objType))
            {
                if (hiddenFields[objType].Contains(fieldName)) hiddenFields[objType].Remove(fieldName);
            }
        }

        public void registerForDataCollection(string fieldName)
        {
            if (!collectDataDict.ContainsKey(fieldName))
            {
               
                List<DateAndValue> tmpl = new List<DateAndValue>();
                collectDataDict.Add(fieldName, tmpl);
            }
        }
        
        public void deRegisterForDataCollection(string fieldName)
        {
            if (collectDataDict.ContainsKey(fieldName))
            {
                collectDataDict.Remove(fieldName);   
            }
        }
        public List<DateAndValue> getCollectedData(string fieldName)
        {
            if (collectDataDict.ContainsKey(fieldName))
            {
                return collectDataDict[fieldName];
            }
            else return null;
        }
        public ListViewItem[] getItemDataAsListViewItems()
        {
            List<ListViewItem> lvList = new List<ListViewItem>();
            JsonSerializer js = new JsonSerializer { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            JObject o = JObject.FromObject(this, js);
            List<string> hiddenList;
            if (hiddenFields.ContainsKey(this.GetType().ToString())) hiddenList = hiddenFields[this.GetType().ToString()]; else hiddenList = new List<string>();
            foreach (KeyValuePair<string, JToken> item in o)
            {
                if (!hiddenList.Contains(item.Key))
                {
                    if (item.Value.Type.ToString() != "Object")
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = item.Key;
                        lvi.SubItems.Add(item.Value.ToString());
                        if (collectDataDict.ContainsKey(item.Key)) lvi.SubItems.Add("true"); else lvi.SubItems.Add("false");
                        lvList.Add(lvi);
                    }
                    else
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = item.Key;
                        lvi.SubItems.Add("Object");
                        lvi.SubItems.Add("false");
                        lvList.Add(lvi);
                    }
                }
            }
            return lvList.ToArray<ListViewItem>();
        }
        
        public virtual void tick()
        {
            if (collectDataDict.Count > 0)
            {
                foreach (KeyValuePair<string, List<DateAndValue>> item in collectDataDict)
                {
                    //Get the value for the Field registered for data collection as double
                    double dt = Convert.ToDouble(typeof(CProducer).GetField(item.Key).GetValue(this));
                    item.Value.Add(new DateAndValue(CMainTicker.gameDateTime, dt));
                }
            }
        }

    }
}
