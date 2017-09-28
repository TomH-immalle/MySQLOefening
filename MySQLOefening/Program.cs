using System;
using MySql.Data.MySqlClient;

namespace MySQLOefening
{
    class Program
    {
        static string version = "0.1";
        public static void Query()
        {
            MySqlConnection comm = new MySqlConnection();
            comm.ConnectionString = "Server = 192.168.56.101;Port = 3306; Database = world;Uid = root;Pwd = root; ";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = comm;

            comm.Open();

            cmd.CommandText = "SELECT count(*) FROM Country";

            Console.WriteLine("{0}", cmd.ExecuteScalar());
        }
        public static void Query2()
        {
            MySqlConnection comm = new MySqlConnection();
            comm.ConnectionString = "Server = 192.168.56.101;Port = 3306; Database = world;Uid = root;Pwd = root; ";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = comm;

            comm.Open();

            cmd.CommandText = "SELECT Name FROM Country";

            Console.WriteLine("{0}", cmd.ExecuteReader());
        }

        static void Main(string[] args)
        {




            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-v":
                        Console.WriteLine("Versie {0}", version);
                        break;
                    case "-allcountries":
                        Query();
                        break;
                    case "-countries":
                        Query2();
                        break;
                    default:
                        Console.WriteLine("Onbekend argument");
                        break;
                }
                //Console.WriteLine(args[0]);
            }
        }
    }
}