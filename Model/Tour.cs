//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kyrsah.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tour
    {
        public Tour()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public decimal cost { get; set; }
        public string location { get; set; }
        public string location_on_map { get; set; }
        public double rating { get; set; }
        public byte[] image { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime return_date { get; set; }
    
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
