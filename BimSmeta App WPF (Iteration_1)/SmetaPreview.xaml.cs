using System;
//using System.Windows.Forms;
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
using System.Windows.Shapes;

namespace BimSmeta_App_WPF__Iteration_1_
{
    /// <summary>
    /// Логика взаимодействия для SmetaPreview.xaml
    /// </summary>
    public partial class SmetaPreview : Window
    {

        public class TestData
        {
            public string Column1;
            public string Column2;
            public string Column3;
            public string Column4;
            public string Column5;
            public string Column6;
            public string Column7;
        }

        public SmetaPreview()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            object obj = new object();
            SmetaPreviewGrid.Items.Add(obj);
        }

        private void Button_Project_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void Button_LoadProject_Click(object sender, RoutedEventArgs e)
        {
            LoadProject loadProject = new LoadProject();
            loadProject.Show();
            this.Hide();
        }

        private void Button_Constructor_Click(object sender, RoutedEventArgs e)
        {
            Constructor constructor = new Constructor();
            constructor.Show();
            this.Hide();
        }

        private void Button_Reference_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(null, "C:\\Users\\rusla\\OneDrive\\Рабочий стол\\Интерфейс Дипломной проги\\BimSmeta App WPF (Iteration_1)\\BimSmeta App WPF (Iteration_1)\\Resourses\\BIM-Smeta AutoBuilder Help.chm");
        }

        private void ViewItemTrackingButton_Click(object sender, RoutedEventArgs e)
        {
            SmetaClass smetaClass = new SmetaClass();
            smetaClass.BIMtoFER_Linking();

            List<SmetaClass> list = new List<SmetaClass>();
            SmetaPreviewGrid.Items.Clear();
            foreach (var item in StorageClass.smetaClasses)
            {
                list.Add(item);
            }

            SmetaPreviewGrid.ItemsSource = list;

            CostTextBlock.Text = "Итоговая стоимость : " + StorageClass.TotalCost.ToString();
        }
    }
}
