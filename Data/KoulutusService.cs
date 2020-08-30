using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace kouluilm.Data
{
    public class KoulutusService
    {
        public Task<List<Koulutus>> GetKoulutusAsync()
        {
            List<Koulutus> koulutukset = new List<Koulutus>();
            Koulutus koulutus = new Koulutus();

            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var sql = connection.CreateCommand();
                sql.CommandText = "SELECT * FROM koulutus_koulutukset";

                using(var reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        koulutus = new Koulutus();
                        koulutus.Koulutus_ID = reader.GetInt32(0).ToString();
                        koulutus.Nimi = reader.GetString(1);
                        koulutukset.Add(koulutus);
                    }
                }
            }

            Task<List<Koulutus>> task = Task.FromResult(koulutukset);
            return task;
        }
    }
}
