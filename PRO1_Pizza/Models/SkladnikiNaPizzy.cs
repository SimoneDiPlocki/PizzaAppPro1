using System;
using System.Collections.Generic;

namespace PRO1_Pizza.Models
{
    public partial class SkladnikiNaPizzy
    {
        public int IdSkladniku { get; set; }
        public int IdPizza { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Skladnik IdSkladnikuNavigation { get; set; }
    }
}
