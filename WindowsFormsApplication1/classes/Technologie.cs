using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diety.helpers;
using Diety.Properties;

using cornerbtn = GaryPerkin.UserControls.Buttons.RoundButton;

namespace Diety.classes
{
   public  class Technologie
    {
       public string Naam { get; set; }
       public List<Niveau> Niveaus { get; set; }
       public TechVisual Visual { get; set; }
       public bool WordtOnderzocht { get; set; }
       public bool Beschikbaar { get; set; }

       internal void UpdateStatus(object sender, EventArgs e)
       {
           WordtOnderzocht = !WordtOnderzocht;
           ((cornerbtn)sender).BackColor = WordtOnderzocht ? Color.LawnGreen : Color.Red;
         }

       public void Onderzoek(int modifier)
       {
          
           var actiefniveau = Niveaus.FirstOrDefault(x => x.Active);
           if (actiefniveau != null)
           {
               actiefniveau.Progress += modifier;
               if (actiefniveau.Progress >= actiefniveau.Onderzoekslengte)
               {
                   actiefniveau.Progress = actiefniveau.Onderzoekslengte;
                   WordtOnderzocht = false;
                  
               }
           }
           Visual.btn.Text = actiefniveau.Naam + " (" + actiefniveau.Progress + "/" + actiefniveau.Onderzoekslengte + ")";
           
       }

       public Niveau getActiefNiveau()
       {
           return Niveaus.FirstOrDefault(x => x.Active);
       }

       public Niveau GetVolgendNiveau()
       {
           var actief = getActiefNiveau();
           return actief == null ? null : Niveaus.FirstOrDefault(x =>x.Level == getActiefNiveau().Level + 1);
       }

       public void Setbutton(bool init = false)
       {
           var actiefNiveau = getActiefNiveau();
           if (actiefNiveau == null)
           {
               return;
           }
           if(init) 
           Visual.btn.Click += UpdateStatus;
           Visual.btn.Text = actiefNiveau.Naam + " (" + actiefNiveau.Progress + "/" + actiefNiveau.Onderzoekslengte + ")";
       }
    }



    public class TechVisual
    {
        public Button btn { get; set; }
        public bool Toegevoegd { get; set; }
    }

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
            return Niveaucompletetext;
        }
    }
}
