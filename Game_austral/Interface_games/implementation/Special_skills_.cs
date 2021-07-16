using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game_austral.Interface_games.implementation
{
    class Special_skills_ : ISpecial_skills
    {
        public string Special_ { get; set; } = " Спец.умение - Лечение отряда";

        public void Add_Special_skills(ListBox list)
        {
            list.Items.Add(Special_);
        }
    }
}
