using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimSmeta_App_WPF__Iteration_1_
{
    static class StorageClass
    {
        public static List<XMLProcessing> xMLProcessings = new List<XMLProcessing>();
        public static List<IfcWallClass> ifcWallClasses = new List<IfcWallClass>();
        public static List<SmetaClass> smetaClasses = new List<SmetaClass>();
        public static double TotalCost = 0;
    }
}
