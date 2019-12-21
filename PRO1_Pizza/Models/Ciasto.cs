using System;
using System.Collections.Generic;

namespace PRO1_Pizza.Models
{
    public partial class Ciasto
    {
        public Ciasto()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdCiasta { get; set; }
        public string Nazwa { get; set; }
        public int CenaCiasta { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
