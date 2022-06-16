using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSVApp
{
    public class Database
    {
        private string csvFile;
        private Record record;

        public Database(string csvFile)
        {
            this.csvFile = csvFile;
        }

        /// <summary>
        /// Create Record and save to CSV file
        /// </summary>
        /// <param name="input">Input from console, checked if is in format "STRING, INT"</param>
        public void AddNewRecord(string input)
        {
            string[] splitedInput = input.Split(',');
            splitedInput[0] = Regex.Replace(splitedInput[0], @"\s+", "");
            record = new Record(splitedInput[0], int.Parse(splitedInput[1]));

            Save(record);
        }

        // Save record to csv file like new line
        private void Save(Record record)
        {
            using (StreamWriter sw = new StreamWriter(csvFile, true))
            {
                string newLine = record.ToString();

                sw.WriteLine(newLine);
                
                sw.Flush();
            }
        }
        
        /// <summary>
        /// Count of one user and his minutes
        /// </summary>
        /// <returns>List of Record, User and his minutes</returns>
        public List<Record> CountedUsersAndMinutes()
        {
            var usersAndMinutes = GetRecords();

            List<Record> countedRecords = new List<Record>();

            foreach (var item in usersAndMinutes)
            {
                if (countedRecords.Exists(x => x.Name == item.Name))
                {
                    var finded = countedRecords.Find(x => x.Name == item.Name);
                    var index = countedRecords.IndexOf(finded);
                    finded.Minutes += item.Minutes;
                    countedRecords.RemoveAt(index);
                    countedRecords.Insert(index, finded);
                }
                else
                {
                    countedRecords.Add( new Record(item.Name, item.Minutes));
                }
            }

            return countedRecords;
        }        

        /// <summary>
        /// Get all Records from CSV file
        /// </summary>
        /// <returns>List of Record from CSV file</returns>
        public List<Record> GetRecords()
        {
                using (StreamReader sr = new StreamReader(csvFile))
                {
                    string s;
                    List<Record> records = new List<Record>();

                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] splitedLine = s.Split(';');

                        records.Add(new Record(splitedLine[0], int.Parse(splitedLine[1])));
                    }

                    return records;
                }
        }               

        /// <summary>
        /// Check correct input format like "string, int"
        /// </summary>
        /// <param name="input">Input from console</param>
        /// <returns>True || false</returns>
        public bool IsInGoodFormat(string input)
        {
            if(input == null)
            {
                return false;
            }            

            string[] inputs = input.Split(',');

            if (inputs.Length == 2 && inputs[0] != "" && int.TryParse(inputs[1], out int i))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
