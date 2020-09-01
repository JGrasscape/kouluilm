using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace kouluilm.Data
{
    public class VarausService
    {
        public Task<List<Varaus>> GetVarausAsync(string sql1, string sql2)
        {
            // Muuttujat
            List<Varaus> varaukset = new List<Varaus>();
            Varaus varaus = new Varaus();

            // SQLite-kannan tiedot
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            // Avataan yhteys tietokantaan
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var sql = connection.CreateCommand();
                sql.CommandText = "SELECT * FROM varaukset WHERE resurssi_id IN (" + sql2 + "0)" + sql1 + " ORDER BY varauspvm, kloalku";

                using(var reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        // Luetaan rivin tiedot olioon
                        varaus = new Varaus();
                        varaus.Varaus_ID = reader.GetInt32(0);
                        varaus.Resurssi_ID = reader.GetInt32(1);
                        //varaus.Varauspvm = reader.GetDateTime(2);
                        varaus.Kloalku = reader.GetString(3);
                        varaus.Kloloppu = reader.GetString(4);
                        varaus.Varaaja = reader.GetString(5);
                        //varaus.Varattupvm = reader.GetDateTime(6);
                        varaus.Aihe = reader.GetString(7);

                        varaukset.Add(varaus);
                    }
                }
            }

            Task<List<Varaus>> task = Task.FromResult(varaukset);
            return task;
        }
    }
}
