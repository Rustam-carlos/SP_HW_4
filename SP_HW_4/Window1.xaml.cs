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

namespace SP_HW_4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Не_сохранять_Click(object sender, RoutedEventArgs e)
        {            
            Application.Current.Shutdown();
        }

        private void Отменить_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            MainWindow x = new MainWindow();
            x.Save();
            Application.Current.Shutdown();
        }
    }
}
