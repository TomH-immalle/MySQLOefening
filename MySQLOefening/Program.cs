﻿using System;
using MySql.Data.MySqlClient;

namespace MySQLOefening
{
    class Program
    {
        static string version = "0.3";
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
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}", reader[0]));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Dit is versie {0} van DBQuerier.", version);
            Console.WriteLine("Kies je optie.");
            Console.WriteLine("1. Hoeveel landen zijn er.");
            Console.WriteLine("2. Welke landen zijn er.");
            int antw = Convert.ToInt32(Console.ReadLine());
            if (antw == 1)
            {
                Query();
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

            else
            {
                Query2();

            }
            }
        }
    }
