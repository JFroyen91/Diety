using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diety.classes;

namespace Diety.helpers
{
    public class TechnologieLibrary : Helpers
    {
        public static Technologie VoedselVerzamelenTechnologie ()
        {
            var tech = new Technologie
            {
                WordtOnderzocht = false,
                Naam = "VoedselVerzamelenTechnologie",
                Visual = new TechVisual{btn = new Button{ Location = new Point(2,25+techbuttonloc) , Size = new Size(220,25)}},
                Niveaus = new List<Niveau>
                {
                    new Niveau{Naam = "draagblad" , Niveaubonus = 1 , Active = true, Progress = 0,Onderzoekslengte = 10 , Niveaucompletetext = "Jou volgers kunnen nu meer voedsel dragen dankzij hun grote draagbladeren" , Niveaubonustype = Enums.Grondstoffen.Voedsel , Level =  1},
                    new Niveau{Naam = "draagmand" , Niveaubonus = 1 , Active = false, Progress = 0,Onderzoekslengte = 10 , Niveaucompletetext = "Jou volgers kunnen nu meer voedsel dragen dankzij hun draagmanden" , Niveaubonustype = Enums.Grondstoffen.Voedsel , Level = 2}
                }
            };
            tech.Setbutton(true);
            techbuttonloc += 30;
            return tech;
        }

       
    }
}
