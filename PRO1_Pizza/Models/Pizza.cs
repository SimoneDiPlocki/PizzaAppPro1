using System;
using System.Collections.Generic;

namespace PRO1_Pizza.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaWZamowieniu = new HashSet<PizzaWZamowieniu>();
            SkladnikiNaPizzy = new HashSet<SkladnikiNaPizzy>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }
        public int IdCiasta { get; set; }
        public int CenaPizzy { get; set; }
        public int CenaPromocyjna { get; set; }

        public virtual Ciasto IdCiastaNavigation { get; set; }
        public virtual ICollection<PizzaWZamowieniu> PizzaWZamowieniu { get; set; }
        public virtual ICollection<SkladnikiNaPizzy> SkladnikiNaPizzy { get; set; }
    }
}
