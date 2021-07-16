using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Game_austral.Interface_games;
using Game_austral.Interface_games.implementation;
using System.Windows.Media;

namespace Game_austral.Heroes_game
{
    abstract class Heroes
    {
        public Iskills skills { get; set; }
        public ISpecial_skills Special_Skills { get;set;}

        public void _Skills( ListBox list, string Skills_new)
        {
            skills._Skills( list,  Skills_new);
        }
        public void Add_Special_skills( ListBox list)
        {
            Special_Skills.Add_Special_skills( list);
        }



        abstract public void Add_race_combo(ComboBox cb);
        abstract public void Delet_character_( TextBox Id_hero);
        abstract public void Add_type_combo(ComboBox cb);
        abstract public void Add_type_Hero(string resylt_combo);
    abstract  public void Add_Skills(TextBox tx1, TextBox tx2, TextBox tx3, TextBox tx4, ListBox list,  string res1);
        abstract public  List<Hero> Show_hero_type(ListBox list);
       
        
        abstract public bool Change_character(TextBox name, TextBox update_specialized);
        abstract public void Display( TextBox txt,TextBox txt2, ListBox list,MediaElement media, MediaTimeline timeline);
    }

}
