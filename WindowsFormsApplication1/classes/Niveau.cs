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
        public bool VoorwaardenVoldaan { get; set; }
        public int Level { get; set; }
        public bool Active { get; set; }
        public int TijdNodig { get; set; }
        public int Progress { get; set; }
        public int Niveaubonus { get; set; }
        public Enums.Bonussen Niveaubonustype { get; set; }
        public string Niveaucompletetext { get; set; }
        public string Naam { get; set; }
        public List<Grondstof> grondstoffenNodig { get; set; }

        public string Complete()
        {
            switch (Niveaubonustype)
            {
                case  Enums.Bonussen.VoedselVerzamelGrootte :
                    VoedselVerzamelGrootte += Niveaubonus;
                    break;
                case Enums.Bonussen.VoedselVerzamelKans:
                    VoedselVerzamelKans += Niveaubonus;
                    break;
                case Enums.Bonussen.VoedselOpslagGrootte:
                    VoedselOpslagGrootte += Niveaubonus;
                    break;
                case Enums.Bonussen.HoutVerzamelGrootte:
                    HoutVerzamelGrootte += Niveaubonus;
                    break;
                case Enums.Bonussen.HuisNiveau:
                    HuisNiveau += Niveaubonus;
                    break;
            }
            
            
            
            return Niveaucompletetext;
        }

        public bool Checkvoorwaarden()
        {
            foreach (var grondstof in grondstoffenNodig)
            {
                if (Progress ==0 && MijnGeloof.GetGrondstof(grondstof.GrondstofType) < grondstof.Waarde)
                    return false;
            }
            return true;
        }
    }

}
