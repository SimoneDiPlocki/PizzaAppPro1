using System;
using System.Collections.Generic;

namespace PRO1_Pizza.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            SkladnikiNaPizzy = new HashSet<SkladnikiNaPizzy>();
        }

        public int IdSkladniku { get; set; }
        public string Nazwa { get; set; }
        public int CenaSkladniku { get; set; }

        public virtual ICollection<SkladnikiNaPizzy> SkladnikiNaPizzy { get; set; }
    }
}
