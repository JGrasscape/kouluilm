using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System;

namespace kouluilm.Data
{
    public class IlmoSearchService
    {
        public Task<List<IlmoSearch>> GetIlmoSearchByVaraajaAsync(string varaaja)
        {
            // Muuttujat
            List<IlmoSearch> ilmoSearches = new List<IlmoSearch>();
            IlmoSearch ilmoSearch;

            // SQLite-kannan tiedot
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            // Avataan yhteys tietokantaan
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var sql = connection.CreateCommand();
                sql.CommandText = @"
                SELECT i.varaus_id,       
                    i.varaaja,
                    i.nimi AS osallistuja,       
                    v.varauspvm AS pvm,
                    v.kloalku,
                    v.kloloppu,
                    k.nimi AS koulutus,
                    r.nimi AS sijainti
                FROM koulutus_ilmoittautumiset i
                LEFT JOIN varaukset v ON i.linkki_varaus_id = v.varaus_id
                LEFT JOIN koulutus_koulutukset k ON i.koulutus_id = k.koulutus_id
                LEFT JOIN koulutus_resurssit r ON v.resurssi_id = r.resurssi_id
                WHERE i.varaaja='" + varaaja + "'";
                
                using(var reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        // Luetaan rivin tiedot olioon
                        ilmoSearch = new IlmoSearch();
                        ilmoSearch.Varaus_ID = reader.GetInt32(0);
                        ilmoSearch.Varaaja = reader.GetString(1);
                        ilmoSearch.Osallistuja = reader.GetString(2);
                        ilmoSearch.Pvm = reader.GetDateTime(3);
                        ilmoSearch.KloAlku = reader.GetString(4);
                        ilmoSearch.KloLoppu = reader.GetString(5);
                        ilmoSearch.Koulutus = reader.GetString(6);
                        ilmoSearch.Sijainti = reader.GetString(7);

                        ilmoSearches.Add(ilmoSearch);
                    }
                }
            }

            Task<List<IlmoSearch>> task = Task.FromResult(ilmoSearches);
            return task;
        }
    }
}