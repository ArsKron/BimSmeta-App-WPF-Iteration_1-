using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BimSmeta_App_WPF__Iteration_1_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static LoadProject LoadProject;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_LoadProject_Click(object sender, RoutedEventArgs e)
        {
                LoadProject = new LoadProject();
                LoadProject.Show();
                this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Constructor_Click(object sender, RoutedEventArgs e)
        {
            Constructor constructor = new Constructor();
            constructor.Show();
            this.Hide();
        }

        private void Button_Preview_Click(object sender, RoutedEventArgs e)
        {
            SmetaPreview smetaPreview = new SmetaPreview();
            smetaPreview.Show();
            this.Hide();
        }

        private void Button_Reference_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(null, "C:\\Users\\rusla\\OneDrive\\Рабочий стол\\Интерфейс Дипломной проги\\BimSmeta App WPF (Iteration_1)\\BimSmeta App WPF (Iteration_1)\\Resourses\\BIM-Smeta AutoBuilder Help.chm");
        }

        private void ReviewPathToBimButton_Click(object sender, RoutedEventArgs e)
        {
            XbimProcessing xbimProcessing = new XbimProcessing();
            xbimProcessing.OpenIfc();
            if (xbimProcessing.CheckIfc())
            {
                xbimProcessing.VolumeCalculate();
                //MessageBox.Show(xbimProcessing.temp);
            }
        }

        private void ReviewPathToFER_Button_Click(object sender, RoutedEventArgs e)
        {
            XMLProcessing xMLProcessing = new XMLProcessing();
            xMLProcessing.OpenFER();
        }
    }
}
