using System;
using System.Collections.Generic;

namespace PRO1_Pizza.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            PizzaWZamowieniu = new HashSet<PizzaWZamowieniu>();
        }

        public int IdZamowienia { get; set; }
        public int SumaCen { get; set; }
        public string Miasto { get; set; }
        public string Adres { get; set; }
        public int? NrMieszkania { get; set; }
        public int KodPocztowy { get; set; }
        public TimeSpan PrzewidywanyCzasDostawy { get; set; }
        public int StatusOplacenia { get; set; }
        public int IdDostawcy { get; set; }

        public virtual Dostawca IdDostawcyNavigation { get; set; }
        public virtual StatusOplacenia StatusOplaceniaNavigation { get; set; }
        public virtual ICollection<PizzaWZamowieniu> PizzaWZamowieniu { get; set; }
    }
}
