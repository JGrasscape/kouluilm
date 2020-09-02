using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace kouluilm.Data
{
    public class IlmoittautuminenService
    {
        public Task<int> GetOsallistujatAsync(int linkki_varaus_id)
        {
            // Muuttujat
            int osallistujat = 0;

            // SQLite-kannan tiedot
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            // Avataan yhteys tietokantaan
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var sql = connection.CreateCommand();
                sql.CommandText = "SELECT COUNT(varaus_id) FROM koulutus_ilmoittautumiset WHERE linkki_varaus_id=" + linkki_varaus_id;

                //osallistujat = (int)sql.ExecuteScalar();
                using(var reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        osallistujat = reader.GetInt32(0);
                    }
                }
            }

            Task<int> task = Task.FromResult(osallistujat);
            return task;
        }
    }
}
