//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainProgram
{
    using System;
    using System.Collections.Generic;
    
    public partial class VW_AgentDetails
    {
        
        public bool Content
        {
            get
            {
                if(Convert.ToInt32(НоваяСкидка) <= 5)
                {
                    return false;
                }
                return true;
            }
        }
        public string NewLogo
        {
            get
            {
                if(Logo == "нет")
                {
                    return null;
                }
                return "Resources" + Logo;
            }
        }
        public string НоваяСкидка
        {
            get
            {
                if(Скидка == null)
                {
                    return "0";
                }
                return Convert.ToString(Скидка);
            }
        }
        public int IDAgent { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Priority { get; set; }
        public string Тип { get; set; }
        public Nullable<int> Скидка { get; set; }
        public string Logo { get; set; }
    }
}
