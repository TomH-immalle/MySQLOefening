using System;
using MySql.Data.MySqlClient;

namespace MySQLOefening
{
    class Program
    {
        static string version = "0.5";
        static string ip;
        static string name;
        static string pwd;

        private static MySqlCommand getCommand()
        {
            MySqlConnection comm = new MySqlConnection();
            comm.ConnectionString = "Server = "+ip+";Port = 3306; Database = world;Uid = "+name+";Pwd = "+pwd+"; ";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = comm;

            comm.Open();

            return cmd;
        }

        public static void Query()
        {
            var cmd = getCommand();

            cmd.CommandText = "SELECT count(*) FROM Country";

            Console.WriteLine("{0}", cmd.ExecuteScalar());
        }
        public static void Query2()
        {
            var cmd = getCommand();

            cmd.CommandText = "SELECT Name FROM Country";
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}", reader[0]));
            }
        }

        public static void Query3(string zoekParameter)
        {
            var cmd = getCommand();

            cmd.CommandText = "SELECT * FROM Country WHERE Name LIKE @zoekParameter";
            cmd.Parameters.AddWithValue("@zoekParameter", "%"+ zoekParameter +"%");
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}", reader[1]));
                
            }
        }

        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                if (args[0] == "help") 
                {
                Console.WriteLine("Geef ip, username en password in.");
                return;
                }
                return;

            }
            else if(args.Length != 3)
            {
                Console.WriteLine("Foute argumenten.");
                return;
            }
            ip = args[0];
            name = args[1];
            pwd = args[2];
            while (true)
            {   
                Console.WriteLine();
                Console.WriteLine("Dit is versie {0} van WordDBQuerier.", version);
                Console.WriteLine();
                Console.WriteLine("Kies je optie.");
                Console.WriteLine("1. Hoeveel landen zijn er.");
                Console.WriteLine("2. Welke landen zijn er.");
                Console.WriteLine("3. Een land zoeken.");
                Console.WriteLine();
                int antw = Convert.ToInt32(Console.ReadLine());
                if (antw == 1)
                {
                    Query();
                }

                else if (antw == 2)
                {
                    Query2();

                }
                else if (antw == 3)
                {
                    Console.WriteLine("Welk land zoek je?");
                    string antw2 = Console.ReadLine();
                    Query3(antw2);
                }
            }

            /*switch (args[0])
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
           }*/

        }
    }
    }
