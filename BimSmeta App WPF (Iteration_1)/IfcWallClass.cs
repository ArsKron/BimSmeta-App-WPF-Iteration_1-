using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimSmeta_App_WPF__Iteration_1_
{
    internal class IfcWallClass
    {
        public int n;
        public string name;
        public double volume;

        public IfcWallClass(int num, string wallName, double Volume)
        {
            this.n = num;
            this.name = wallName;
            this.volume = Volume;
        }
    }
}
