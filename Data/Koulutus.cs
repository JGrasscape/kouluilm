using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kouluilm.Data
{
    public class Koulutus
    {
        public string Koulutus_ID { get; set; } // Olisi muuten int, mutta InputSelect bind-value toimii vain stringiin
        public string Nimi { get; set; }
        public string Asiasanat { get; set; }
        public DateTime Alkupvm { get; set; }
        public DateTime Loppupvm { get; set; }
        public string Selite { get; set; }
        public string Kieltosanat { get; set; }
        public bool piilotettu { get; set; }
    }
}
