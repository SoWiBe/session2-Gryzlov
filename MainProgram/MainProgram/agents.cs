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
    
    public partial class agents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public agents()
        {
            this.productSale = new HashSet<productSale>();
        }
    
        public int IdType { get; set; }
        public string Type { get; set; }
        public int IDAgent { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Priority { get; set; }
        public string Director { get; set; }
        public Nullable<double> INN { get; set; }
        public Nullable<double> KPP { get; set; }
    
        public virtual type_agents type_agents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productSale> productSale { get; set; }
    }
}
