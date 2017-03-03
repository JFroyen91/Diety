using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diety.helpers;

namespace Diety.classes
{
    public class Power
    {
        public PowerTechVisual Visual { get; set; }
        public bool Beschikbaar { get; set; }
        public EventHandler Gebruikpower { get; set; }
        public int UnlockWaarde { get; set; }

        public Power()
        {
        }
    }
}
