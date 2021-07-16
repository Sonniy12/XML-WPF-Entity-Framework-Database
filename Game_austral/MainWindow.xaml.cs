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

namespace Game_austral
{
    /// <summary>
    /// 
    /// ТИП ГЕРОЕВ ДОБАВЛЯЕТСЯ В ЛИСТ ПОСЛЕ ЗАКРЫТИЯ ОКОН !!!!
    /// 
    /// 
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            Window_option_myth op_m = new Window_option_myth ();
            op_m.Owner = this;
            op_m.Show();
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            Window_option_legend legend = new Window_option_legend () ;
            legend.Owner = this;
            legend.Show();
        }
    }
}
