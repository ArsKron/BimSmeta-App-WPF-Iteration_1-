using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xbim.Ifc;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.SharedBldgElements;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;

namespace BimSmeta_App_WPF__Iteration_1_
{
    internal class XbimProcessing
    {
        string filename = "";
        public string temp = "";
        int WallsCounter;
        int WallQuantityBorder = 1000;

        public bool CheckIfc()
        {
            if (filename.Length <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void OpenIfc()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы IFC|*.ifc";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Подсчитать объём стен
        /// </summary>
        public void VolumeCalculate()
        {
            using (var model = IfcStore.Open(filename))
            {
                var MyWalls = model.Instances.OfType<IfcWall>();
                WallsCounter = MyWalls.Count();
                int i = 0;
                temp += "Всего стен: " + WallsCounter + "\n";
                foreach (var obj in MyWalls)
                {
                    var volume = GetVolume(obj);
                    temp += "У стены номер " + i + " объём: " + volume.ToString() + " м^3\n";

                    string name1 = obj.Name.ToString();
                    string vol = volume.ToString();
                    vol = vol.Replace(".", ",");
                    double volume1 = Convert.ToDouble(vol);
                    IfcWallClass ifcWallClass = new IfcWallClass(i, name1, volume1);
                    StorageClass.ifcWallClasses.Add(ifcWallClass);

                    i++;
                    if (i > WallQuantityBorder)
                    {
                        break;
                    }
                }
            }
        }

        public double CalculateWallCost(double Volume, double Cost)
        {
            return Volume * Cost / 1000.0;
        }

        /// <summary>
        /// Получить площадь выбранного объекта Ifc
        /// </summary>
        /// <param name="product">Объект Ifc у которого имеется площадь</param>
        /// <returns></returns>
        private static IIfcValue GetArea(IIfcProduct product)
        {
            //try to get the value from quantities first
            var area =
                //get all relations which can define property and quantity sets
                product.IsDefinedBy

                //Search across all property and quantity sets. 
                //You might also want to search in a specific quantity set by name
                .SelectMany(r => r.RelatingPropertyDefinition.PropertySetDefinitions)

                //Only consider quantity sets in this case.
                .OfType<IIfcElementQuantity>()

                //Get all quantities from all quantity sets
                .SelectMany(qset => qset.Quantities)

                //We are only interested in areas 
                .OfType<IIfcQuantityArea>()

                //We will take the first one. There might obviously be more than one area properties
                //so you might want to check the name. But we will keep it simple for this example.
                .FirstOrDefault()?
                .AreaValue;

            if (area != null)
                return area;

            //try to get the value from properties
            return GetProperty(product, "Area");
        }

        /// <summary>
        /// Получить объём выбранного объекта Ifc
        /// </summary>
        /// <param name="product">Объект Ifc у которого имеется объём</param>
        /// <returns></returns>
        private static IIfcValue GetVolume(IIfcProduct product)
        {
            var volume = product.IsDefinedBy
                .SelectMany(r => r.RelatingPropertyDefinition.PropertySetDefinitions)
                .OfType<IIfcElementQuantity>()
                .SelectMany(qset => qset.Quantities)
                .OfType<IIfcQuantityVolume>()
                .FirstOrDefault()?.VolumeValue;
            if (volume != null)
                return volume;
            return GetProperty(product, "Volume");
        }

        /// <summary>
        /// Получение площади или объёма выбранного объёекта Ifc
        /// </summary>
        /// <param name="product">Объект Ifc у которого есть свойства</param>
        /// <param name="name">То, что мы хотим получить из свойств: "Area" или "Volume" (или, возможно!!!, что-то ещё)</param>
        /// <returns></returns>
        private static IIfcValue GetProperty(IIfcProduct product, string name)
        {
            return
                //get all relations which can define property and quantity sets
                product.IsDefinedBy

                //Search across all property and quantity sets. You might also want to search in a specific property set
                .SelectMany(r => r.RelatingPropertyDefinition.PropertySetDefinitions)

                //Only consider property sets in this case.
                .OfType<IIfcPropertySet>()

                //Get all properties from all property sets
                .SelectMany(pset => pset.HasProperties)

                //lets only consider single value properties. There are also enumerated properties, 
                //table properties, reference properties, complex properties and other
                .OfType<IIfcPropertySingleValue>()

                //lets make the name comparison more fuzzy. This might not be the best practise
                .Where(p =>
                    string.Equals(p.Name, name, System.StringComparison.OrdinalIgnoreCase) ||
                    p.Name.ToString().ToLower().Contains(name.ToLower()))

                //only take the first. In reality you should handle this more carefully.
                .FirstOrDefault()?.NominalValue;
        }
    }
}
