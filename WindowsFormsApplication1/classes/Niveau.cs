using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diety.helpers;

namespace Diety.classes
{
    public class Niveau : Helpers
    {
        public int Level { get; set; }
        public int XPNodig { get; set; }
        public bool Active { get; set; }
        public int Onderzoekslengte { get; set; }
        public int Progress { get; set; }
        public int Niveaubonus { get; set; }
        public Enums.Bonussen Niveaubonustype { get; set; }
        public string Niveaucompletetext { get; set; }
        public string Naam { get; set; }

        public string Complete()
        {
            if (Niveaubonustype == Enums.Bonussen.VoedselVerzamelGrootte)
            {
                VoedselVerzamelGrootte += Niveaubonus;
            }
            if (Niveaubonustype == Enums.Bonussen.VoedselVerzamelKans)
            {
                VoedselVerzamelKans += Niveaubonus;
            }
            if (Niveaubonustype == Enums.Bonussen.VoedselOpslagGrootte)
            {
                VoedselOpslagGrootte += Niveaubonus;
            }
            return Niveaucompletetext;
        }
    }
}
