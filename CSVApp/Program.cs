using System;

namespace CSVApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            Database db = new Database("save.csv");

            string temp = AppDomain.CurrentDomain.BaseDirectory;
            string sPath = Path.Combine(temp, "save.csv");

            if (!(File.Exists(sPath)))
            {
                File.CreateText(sPath);
            }

            do
            {
                Writer.WriteInstruction();

                input = Console.ReadLine();

                if(input.StartsWith('1'))
                {
                    Writer.WriteAll(db);                 
                }
                else if(input.StartsWith('2'))
                {
                    Writer.WriteCounted(db);
                }
                else if(input == "exit")
                {
                    return;
                }
                else if(db.IsInGoodFormat(input))
                {
                    db.AddNewRecord(input);
                    Console.WriteLine("\n NEW USER ADDED \n");
                }
                else
                {
                    Console.WriteLine("\nInput is in wrong format!");
                }

                input = "";

            } while (input == "" || input == null);

            Console.ReadKey();
        }
    }
}