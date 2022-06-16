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
        
        public int Minits { get; set; }

        public Record(string name, int minits)
        {
            this.Name = name;
            this.Minits = minits;
        }

        public override string ToString()
        {
            return this.Name + ";" + this.Minits;
        }
    }
}
