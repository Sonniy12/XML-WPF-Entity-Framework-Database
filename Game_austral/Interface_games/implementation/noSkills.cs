using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Game_austral.Interface_games.implementation
{
    class noSkills : Iskills
    {
        //  public string Skills_new { get; set; } = "нет умений!";
        public void _Skills(ListBox list, string Skills_new)
        {
            list.Items.Add(Skills_new);
        }
      
    }
}
