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
using Game_austral.Heroes_game;
using Game_austral.Interface_games;
using Game_austral.Interface_games.implementation;
namespace Game_austral
{
    /// <summary>
    /// Логика взаимодействия для Window_option_legend.xaml
    /// </summary>
    public partial class Window_option_legend : Window
    {
        legends_Class legends_;
        string result2 = "";
        string result = "";
        List<Hero> heroes;
        public Window_option_legend()
        {
            InitializeComponent();
            heroes = Show_hero_type();
            legends_ = new legends_Class(_tx_1, _tx_2, _tx_3, _tx_4, _listb1, heroes, result);
          
            legends_.Add_type_combo(_cb_1);
            legends_.Add_race_combo(_cb_2);
            
         
        }

        private List<Hero> Show_hero_type()
        {
            List<Hero> heroes;
            using (Game_australEntities connect = new Game_australEntities())
            {
                heroes = (from x in connect.Hero select x).ToList();

                foreach (var x in heroes)
                {
                    _listb1.Items.Add(x.name);
                }
                return heroes;

            }
        }


        private void _cb_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            legends_.Result_comboBox = _cb_1.SelectedItem.ToString();
           // MessageBox.Show(legends_.Result_comboBox);
        }

        private void _cb_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            result2 = _cb_2.SelectedItem.ToString();
          //  MessageBox.Show(result2);
        }

        private void Typ_Add_Click(object sender, RoutedEventArgs e)
        {
            legends_.Add_type_Hero(legends_.Result_comboBox);
        }

        private void Character_Add_Click(object sender, RoutedEventArgs e)
        {
            legends_.Add_Skills(_tx_1,_tx_2,_tx_3,_tx_4,_listb1,result2);
        }


        private void Typ_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_show__Click(object sender, RoutedEventArgs e)
        {
            legends_.Display(txt_nameHero, txt_typeHero, listBox_show, media_el, m_line);
            legends_._Skills(listBox_show, "Применяется умение Легенд!");
            legends_.Add_Special_skills(listBox_show);
        }

        private void Button_Clearshow__Click(object sender, RoutedEventArgs e)
        {
            listBox_show.Items.Clear();
        }

        private void Button_change__Click(object sender, RoutedEventArgs e)
        {
            legends_.Change_character(txt_change_nameHero, txt_change_specializ);
        }

        private void Button_delet__Click(object sender, RoutedEventArgs e)
        {
            legends_.Delet_character_(txt_delet);
            txt_delet.Text = "";
        }

       
       
    }
}
