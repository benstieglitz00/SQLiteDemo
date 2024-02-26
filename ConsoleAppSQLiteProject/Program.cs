using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSQLiteProjectDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            CreateTable(sqlite_conn);
            InsertData(sqlite_conn);
            ReadData(sqlite_conn);
            Console.ReadLine();
        }

        /// <summary>
        /// Create a new SQLite Connection. 
        /// </summary>
        /// <returns></returns>
        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection _conn;
            _conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            try
            {
                _conn.Open();
            }
            catch (Exception ex)
            {

            }
            return _conn;
        }


        /// <summary>
        /// Create some sample tables.
        /// </summary>
        /// <param name="conn"></param>
        static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand cmd;
            string Createsql = "CREATE TABLE IF NOT EXISTS SampleTable (Col1 VARCHAR(20), Col2 INT)";
            string Createsql1 = "CREATE TABLE IF NOT EXISTS SampleTable1 (Col1 VARCHAR(20), Col2 INT)";
            cmd = conn.CreateCommand();
            cmd.CommandText = Createsql;
            cmd.ExecuteNonQuery();
            cmd.CommandText = Createsql1;
            cmd.ExecuteNonQuery();
        }

        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test Text ', 1); ";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test1 Text1 ', 2); ";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test2 Text2 ', 3); ";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO SampleTable1(Col1, Col2) VALUES('Test3 Text3 ', 3); ";
            cmd.ExecuteNonQuery();
        }

        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM SampleTable where Col2 = 2";

            sqlite_datareader = cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }
    }
}