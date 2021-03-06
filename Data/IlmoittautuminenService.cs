using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System;

namespace kouluilm.Data
{
    public class IlmoittautuminenService
    {
        public Task<int> GetOsallistujatCountAsync(int linkki_varaus_id)
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

                osallistujat = int.Parse(sql.ExecuteScalar().ToString());
                
                /*using(var reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        osallistujat = reader.GetInt32(0);
                    }
                }*/
            }

            Task<int> task = Task.FromResult(osallistujat);
            return task;
        }

        public Task<List<Ilmoittautuminen>> GetOsallistujatAsync(int linkki_varaus_id)
        {
            // Muuttujat
            List<Ilmoittautuminen> ilmoittautumiset = new List<Ilmoittautuminen>();
            Ilmoittautuminen ilmoittautuminen = new Ilmoittautuminen();

            // SQLite-kannan tiedot
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            // Avataan yhteys tietokantaan
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var sql = connection.CreateCommand();
                sql.CommandText = "SELECT * FROM koulutus_ilmoittautumiset WHERE linkki_varaus_id=" + linkki_varaus_id + " ORDER BY paikka";

                //osallistujat = (int)sql.ExecuteScalar();
                using(var reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        // Luetaan rivin tiedot olioon
                        ilmoittautuminen = new Ilmoittautuminen();
                        ilmoittautuminen.Varaus_ID = reader.GetInt32(0);
                        ilmoittautuminen.Linkki_Varaus_ID = reader.GetInt32(1);
                        ilmoittautuminen.Koulutus_ID = reader.GetInt32(2);
                        ilmoittautuminen.Paikka = reader.GetInt32(3);
                        ilmoittautuminen.Varaaja = reader.GetString(4);
                        ilmoittautuminen.Varattupvm = reader.GetDateTime(5);
                        ilmoittautuminen.Nimi = reader.GetString(6);
                        ilmoittautuminen.Yksikko = reader.GetString(7);
                        ilmoittautuminen.Puh = reader.GetString(8);
                        if(!reader.IsDBNull(9)) ilmoittautuminen.Koulutus_OK = reader.GetBoolean(9);
                        if(!reader.IsDBNull(10)) ilmoittautuminen.EHRM_OK = reader.GetBoolean(10);

                        ilmoittautumiset.Add(ilmoittautuminen);
                    }
                }
            }

            Task<List<Ilmoittautuminen>> task = Task.FromResult(ilmoittautumiset);
            return task;
        }

        public bool InsertOsallistujaAsync(Ilmoittautuminen ilmo)
        {
            int linkki_varaus_id = ilmo.Linkki_Varaus_ID;
            int koulutus_id = ilmo.Koulutus_ID;
            string varaattupvm = DateTime.Today.ToString("yyyy-MM-dd");
            int paikka = 1;

            // SQLite-kannan tiedot
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./varaus.db";

            // Avataan yhteys tietokantaan
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                // Selvitetään vapaa paikka
                var sql = connection.CreateCommand();
                sql.CommandText = "SELECT paikka FROM koulutus_ilmoittautumiset WHERE linkki_varaus_id=" + linkki_varaus_id + " ORDER BY paikka";
                
                using(var reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (paikka == reader.GetInt32(0))
                            paikka++;                            
                        else
                            break;

                        if (paikka > ilmo.PaikkaLkm)
                            return false;
                    }                  
                }

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCommand = connection.CreateCommand();
                    
                    insertCommand.CommandText = "INSERT INTO koulutus_ilmoittautumiset (linkki_varaus_id, koulutus_id, paikka, varaaja, varattupvm, nimi, yksikko, puh) VALUES (" + linkki_varaus_id + ", " + koulutus_id + ", " + paikka + ", '" + ilmo.Varaaja + "', '" + varaattupvm + "', '" + ilmo.Nimi + "', '" + ilmo.Yksikko + "', '" + ilmo.Puh + "')";
                    
                    insertCommand.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
            }
        }

        public void DeleteOsallistujaAsync(int varaus_id)
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
                    
                    deleteCommand.CommandText = "DELETE FROM koulutus_ilmoittautumiset WHERE varaus_id=" + varaus_id;
                    deleteCommand.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        } 
    }
}
