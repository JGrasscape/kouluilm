using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace kouluilm.Data
{
    public class KoulutusService
    {
        public Task<List<Koulutus>> GetKoulutusAsync(string piilotettu)
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
                sql.CommandText = "SELECT * FROM koulutus_koulutukset WHERE piilotettu " + piilotettu;

                using(var reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        // Luetaan rivin tiedot olioon
                        koulutus = new Koulutus();
                        koulutus.Koulutus_ID = reader.GetInt32(0).ToString();
                        koulutus.Nimi = reader.GetString(1);
                        koulutus.Asiasanat = reader.GetString(2);
                        if(!reader.IsDBNull(3)) koulutus.Alkupvm = reader.GetDateTime(3);
                        if(!reader.IsDBNull(4)) koulutus.Loppupvm = reader.GetDateTime(4);
                        koulutus.Selite = reader.GetString(5);
                        if(!reader.IsDBNull(6)) koulutus.Kieltosanat = reader.GetString(6);
                        koulutus.Piilotettu = reader.GetBoolean(7);

                        koulutukset.Add(koulutus);
                    }
                }
            }

            Task<List<Koulutus>> task = Task.FromResult(koulutukset);
            return task;
        }

        public void UpdateKoulutusAsync(Koulutus koulutus)
        {
            // SQLite-kannan tiedot
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            // Avataan yhteys tietokantaan
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var updateCommand = connection.CreateCommand();
                    int piilotettu = (koulutus.Piilotettu) ? 1 : 0;
                    string alkupvm = koulutus.Alkupvm.ToString("yyyy-MM-dd");
                    string loppupvm = koulutus.Loppupvm.ToString("yyyy-MM-dd");
                    
                    updateCommand.CommandText = "UPDATE koulutus_koulutukset SET nimi='" + koulutus.Nimi + "', asiasanat='" + koulutus.Asiasanat +"', alkupvm='" + alkupvm + "', loppupvm='" + loppupvm + "', selite='" + koulutus.Selite + "', kieltosanat='" + koulutus.Kieltosanat + "', piilotettu='" + piilotettu + "' WHERE koulutus_id=" + koulutus.Koulutus_ID;
                    updateCommand.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }

        public void DeleteKoulutusAsync(Koulutus koulutus)
        {
            // SQLite-kannan tiedot
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            // Avataan yhteys tietokantaan
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var deleteCommand = connection.CreateCommand();
                    
                    deleteCommand.CommandText = "DELETE FROM koulutus_koulutukset WHERE koulutus_id=" + koulutus.Koulutus_ID;
                    deleteCommand.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        } 

        public void InsertKoulutusAsync(Koulutus koulutus)
        {
            // SQLite-kannan tiedot
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            // Avataan yhteys tietokantaan
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCommand = connection.CreateCommand();
                    int piilotettu = (koulutus.Piilotettu) ? 1 : 0;
                    string alkupvm = koulutus.Alkupvm.ToString("yyyy-MM-dd");
                    string loppupvm = koulutus.Loppupvm.ToString("yyyy-MM-dd");
                    
                    insertCommand.CommandText = "INSERT INTO koulutus_koulutukset (nimi, asiasanat, alkupvm, loppupvm, selite, kieltosanat, piilotettu) VALUES ('" + koulutus.Nimi + "', '" + koulutus.Asiasanat + "', '" + alkupvm + "', '" + loppupvm + "', '" + koulutus.Selite + "', '" + koulutus.Kieltosanat + "', " + piilotettu + ")";
                    insertCommand.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        } 
    }
}
