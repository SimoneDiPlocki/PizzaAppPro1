using System;
using System.Collections.Generic;

namespace PRO1_Pizza.Models
{
    public partial class StatusOplacenia
    {
        public StatusOplacenia()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdOplacenia { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
