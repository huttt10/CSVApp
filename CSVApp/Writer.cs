using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApp
{
    public static class Writer
    {
        // Write to console all records
        public static void WriteAll(Database db)
        {            
            var allRecords = db.GetRecords();
            if (allRecords == null || allRecords.Count == 0)
            {
                Console.WriteLine("\n0 USERS! ADD USER FIRST!\n");
                return;
            }

            Console.WriteLine("\nAll users:\n");
            
            foreach (var item in allRecords)
            {
                Console.WriteLine("Name of user: {0}, all minutes: {1}", item.Name, item.Minutes.ToString());
            }
        }

        // Write to console counted records
        public static void WriteCounted(Database db)
        {
            var allCountedRecords = db.CountedUsersAndMinutes();
            if (allCountedRecords == null || allCountedRecords.Count == 0)
            {
                Console.WriteLine("\n0 USERS! ADD USER FIRST!\n");
                return;
            }

            Console.WriteLine("\nCounted time for all users:\n");

            foreach (var item in allCountedRecords)
            {
                Console.WriteLine("Name of user: {0}, all minutes: {1}", item.Name, item.Minutes.ToString());
            }
        }

        // Write to console instructions
        public static void WriteInstructions()
        {
            Console.WriteLine("\nFor write all records type '1' \nOR For count minutes for user type '2' \nOR For add name and minutes type text in format: Name,NUMBER \nFor exit type 'exit'");
        }
    }
}
