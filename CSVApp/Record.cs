using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApp
{
    public class Record
    {
        public string Name { get; set; }
        
        public int Minutes { get; set; }

        public Record(string name, int minutes)
        {
            this.Name = name;
            this.Minutes = minutes;
        }

        public override string ToString()
        {
            return this.Name + ";" + this.Minutes;
        }
    }
}
