using System;
using System.Collections.Generic;

namespace PRO1_Pizza.Models
{
    public partial class Dostawca
    {
        public Dostawca()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdDostawcy { get; set; }
        public string Imie { get; set; }
        public string Transport { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
