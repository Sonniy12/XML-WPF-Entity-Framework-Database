using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game_austral.Interface_games
{
    interface ISpecial_skills
    {
        string Special_ { get; set; }
        void Add_Special_skills( ListBox list );
    }
}
