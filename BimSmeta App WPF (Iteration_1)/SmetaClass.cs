using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimSmeta_App_WPF__Iteration_1_
{
    internal class SmetaClass
    {
        public string ElementCode { get; set; }
        public string ElementID { get; set; }
        public string ElementName { get; set; }
        public string ElementType { get; set; }
        public int Section { get; set; }
        public int Floor { get; set; }
        public double Cost { get; set; }

        public SmetaClass(string Code, string id, string name, int section, int floor, double cost)
        {
            this.ElementCode = Code;
            this.ElementID = id;
            this.ElementName = name;
            this.ElementType = "IfcWall";
            this.Section = section;
            this.Floor = floor;
            this.Cost = cost;
        }

        public SmetaClass()
        {
            this.ElementType = "ifcWall";
        }

        public void BIMtoFER_Linking()
        {
            foreach (var item in StorageClass.ifcWallClasses)
            {
                string vol = StorageClass.xMLProcessings[2].cost;
                vol = vol.Replace(".", ",");
                double cost1 = Convert.ToDouble(vol) * item.volume;
                //string cost_1 = cost1.ToString();
                //if (cost_1.Length >= 5)
                //{
                //    cost_1 = cost_1.Substring(0, 5);
                //}
                //cost1 = Convert.ToDouble(cost_1);

                SmetaClass smetaClass = new SmetaClass(StorageClass.xMLProcessings[2].id, Convert.ToString(item.n), item.name, 1, 1, cost1);
                StorageClass.smetaClasses.Add(smetaClass);

                vol = StorageClass.xMLProcessings[4].cost;
                vol = vol.Replace(".", ",");
                double cost2 = Convert.ToDouble(vol) * item.volume;
                //string cost_2 = cost2.ToString();
                //if(cost_2.Length >= 5)
                //{
                //    cost_2 = cost_2.Substring(0, 5);
                //}
                //cost2 = Convert.ToDouble(cost_2);

                SmetaClass smetaClass1 = new SmetaClass(StorageClass.xMLProcessings[4].id, Convert.ToString(item.n), item.name, 1, 1, cost2);
                StorageClass.smetaClasses.Add(smetaClass);

                StorageClass.TotalCost += cost1 + cost2;
            }
        }
    }
}
