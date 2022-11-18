using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace BimSmeta_App_WPF__Iteration_1_
{
    internal class XMLProcessing
    {
        public string number = "";
        public string id = "";
        public string description = "";
        public string volume = "";
        public string cost = "";

        public void OpenFER()
        {
            XmlDocument xmlDoc = new XmlDocument();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы XML|*.xml";
            string filename = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
            }
            xmlDoc.Load(filename);
            XmlElement element = xmlDoc.DocumentElement;

            foreach (XmlNode xnode in element)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "number")
                    {
                        number = childnode.InnerText;
                    }
                    if (childnode.Name == "id")
                    {
                        id = childnode.InnerText;
                    }
                    if (childnode.Name == "description")
                    {
                        description = childnode.InnerText;
                    }
                    if (childnode.Name == "volume")
                    {
                        volume = childnode.InnerText;
                    }
                    if (childnode.Name == "cost")
                    {
                        cost = childnode.InnerText;
                    }
                }
                StorageClass.xMLProcessings.Add(this);
            }
        }
    }
}
