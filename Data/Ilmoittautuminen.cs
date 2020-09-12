using System;

namespace kouluilm.Data
{
    public class Ilmoittautuminen
    {
        public int Varaus_ID { get; set; }
        public int Linkki_Varaus_ID { get; set; }
        public int Koulutus_ID { get; set; }
        public int Paikka { get; set; }
        public string Varaaja { get; set; }
        public DateTime Varattupvm { get; set; }
        public string Nimi { get; set; }
        public string Yksikko { get; set; }
        public string Puh { get; set; }
        public bool Koulutus_OK { get; set; }
        public bool EHRM_OK { get; set; }
        public int PaikkaLkm { get; set; } // Otetaan talteen ilmoittautumista varten paikkalkm
    }
}