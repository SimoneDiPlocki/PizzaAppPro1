using System;
using System.Collections.Generic;

namespace PRO1_Pizza.Models
{
    public partial class PizzaWZamowieniu
    {
        public int IdPizza { get; set; }
        public int IdZamowienia { get; set; }
        public int Ilosc { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Zamowienie IdZamowieniaNavigation { get; set; }
    }
}
