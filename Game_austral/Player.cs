//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Game_austral
{
    using System;
    using System.Collections.Generic;
    
    public partial class Player
    {
        public int id { get; set; }
        public string nickname { get; set; }
        public Nullable<int> fk_hero { get; set; }
        public Nullable<int> rating { get; set; }
    
        public virtual Hero Hero { get; set; }
    }
}
