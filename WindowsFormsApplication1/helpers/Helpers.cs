using System;
using System.Windows.Forms;

using Diety.classes;

namespace Diety.helpers
{
    public class Helpers :Form
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
        public static int VoedselOpslagGrootte = 0;
        public static int HoutOpslagGrootte = 0;
        public static int HoutVerzamelGrootte = 0;
        public static int HuisNiveau = 0;
        public static int KiesWaardeTussen(int min, int max)
        {
            return Rand.Next(min, max);
        }

        }
}
