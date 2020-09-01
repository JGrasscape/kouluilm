using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace kouluilm.Data
{
    public class ResurssiService
    {
        public Task<List<Resurssi>> GetResurssiAsync()
        {
            // Muuttujat
            List<Resurssi> resurssit = new List<Resurssi>();
            Resurssi resurssi = new Resurssi();

            // SQLite-kannan tiedot
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            // Avataan yhteys tietokantaan
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var sql = connection.CreateCommand();
                sql.CommandText = "SELECT * FROM koulutus_resurssit";

                using(var reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        // Luetaan rivin tiedot olioon
                        resurssi = new Resurssi();
                        resurssi.Resurssi_ID = reader.GetInt32(0);
                        resurssi.Paikkalkm = reader.GetInt32(1);
                        resurssi.Nimi = reader.GetString(2);

                        resurssit.Add(resurssi);
                    }
                }
            }

            Task<List<Resurssi>> task = Task.FromResult(resurssit);
            return task;
        }
    }
}
