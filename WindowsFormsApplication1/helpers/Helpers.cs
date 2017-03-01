using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diety.classes;

namespace Diety.helpers
{
    public class Helpers : Form
    {
        public Timer UpdateTimer { get; set; }
        public int Ticks { get; set; }
        public int TijdVerstreken { get; set; }
        public bool Gewonnen { get; set; }
        public int ImageTimer = 1;
        public static Random Rand = new Random();
        public static Game spel { get; set; }
        public static Geloof MijnGeloof { get; set; }
        public static int Techbuttonloc = 0;
        public static int VoedselVerzamelGrootte = 0;
        public static int VoedselVerzamelKans = 0;
        public static int BepaalWaarde(int min, int max)
        {
            return Rand.Next(min, max);
        }

        }
}
