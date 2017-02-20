using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diety.helpers
{
    public class Helpers
    {
        public static Random Rand = new Random();
        public static int techbuttonloc = 0;
        public static int VoedselVerzamelBonus = 0;

        public static int BepaalWaarde(int min, int max)
        {

            return Rand.Next(min, max);
        }
    }
}
