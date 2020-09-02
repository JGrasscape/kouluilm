using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace kouluilm.Data
{
    public class KoulutusService
    {
        public Task<List<Koulutus>> GetKoulutusAsync()
        {
            // Muuttujat
            List<Koulutus> koulutukset = new List<Koulutus>();
            Koulutus koulutus = new Koulutus();

            // SQLite-kannan tiedot
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            // Avataan yhteys tietokantaan
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var sql = connection.CreateCommand();
                sql.CommandText = "SELECT * FROM koulutus_koulutukset WHERE piilotettu=0";

                using(var reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        // Luetaan rivin tiedot olioon
                        koulutus = new Koulutus();
                        koulutus.Koulutus_ID = reader.GetInt32(0).ToString();
                        koulutus.Nimi = reader.GetString(1);
                        koulutus.Asiasanat = reader.GetString(2);
                        //koulutus.Alkupvm = reader.GetDateTime(3);
                        //koulutus.Loppupvm = reader.GetDateTime(4);
                        koulutus.Selite = reader.GetString(5);
                        //koulutus.Kieltosanat = reader.GetString(6);
                        //koulutus.piilotettu = reader.GetBoolean(7);

                        koulutukset.Add(koulutus);
                    }
                }
            }

            Task<List<Koulutus>> task = Task.FromResult(koulutukset);
            return task;
        }
    }
}
