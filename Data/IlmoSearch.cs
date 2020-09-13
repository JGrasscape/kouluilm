using System;

namespace kouluilm.Data
{
    public class IlmoSearch
    {
        public int Varaus_ID { get; set; }   
        public string Varaaja { get; set; }    
        public string Osallistuja { get; set; }
        public DateTime Pvm { get; set; }
        public string KloAlku { get; set; }
        public string KloLoppu { get; set; }
        public string Koulutus { get; set; }
        public string Sijainti { get; set; }
    }
}