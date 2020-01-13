using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlandMarina.ClassLibrary
{
    public class Dock
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool WaterService { get; set; }
        public bool ElectricalService { get; set; }
    }
}
