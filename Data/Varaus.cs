using System;

namespace kouluilm.Data
{
    public class Varaus
    {
        public int Varaus_ID { get; set; }
        public int Resurssi_ID { get; set; }
        public DateTime Varauspvm { get; set; }
        public string Kloalku { get; set; }
        public string Kloloppu { get; set; }
        public string Varaaja { get; set; }
        public DateTime Varattupvm { get; set; }
        public string Aihe { get; set; }
    }
}