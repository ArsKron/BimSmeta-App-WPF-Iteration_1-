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
using System.Windows.Shapes;

namespace BimSmeta_App_WPF__Iteration_1_
{
    /// <summary>
    /// Логика взаимодействия для LoadProject.xaml
    /// </summary>
    public partial class LoadProject : Window
    {
        public LoadProject()
        {
            InitializeComponent();
        }

        private void LoadProjectWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Project_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
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
    }
}
