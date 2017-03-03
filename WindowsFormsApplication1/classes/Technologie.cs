using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Diety.helpers;

using cornerbtn = GaryPerkin.UserControls.Buttons.RoundButton;

namespace Diety.classes
{
   public  class Technologie : Helpers
    {
       public string Naam { get; set; }
       public List<Niveau> Niveaus { get; set; }
       public PowerTechVisual Visual { get; set; }
       public bool WordtOnderzocht { get; set; }
       public bool Beschikbaar { get; set; }

       internal void UpdateStatus(object sender, EventArgs e)
       {
           WordtOnderzocht = !WordtOnderzocht;
           ((cornerbtn)sender).BackColor = WordtOnderzocht ? Color.LawnGreen : Color.Red;
           var actiefniveau = getActiefNiveau();
           if (actiefniveau.Progress == 0)
           {
               foreach (var benodigdheid in actiefniveau.grondstoffenNodig)
               {
                   MijnGeloof.Grondstoffen.FirstOrDefault(x=>x.GrondstofType == benodigdheid.GrondstofType).Waarde-= benodigdheid.Waarde;
               }
               actiefniveau.Progress += 1;
           }
           spel.UpdateLabels(MijnGeloof, false);
           Visual.btn.Text = actiefniveau.Naam + " (" + actiefniveau.Progress + "/" + actiefniveau.TijdNodig + ") ";
           spel.CheckTechs();
       }

       public void Onderzoek(int modifier)
       {
          
           var actiefniveau = Niveaus.FirstOrDefault(x => x.Active);
           if (actiefniveau != null)
           {
               actiefniveau.Progress += modifier;
               if (actiefniveau.Progress >= actiefniveau.TijdNodig)
               {
                   actiefniveau.Progress = actiefniveau.TijdNodig;
                   WordtOnderzocht = false;
                  
               }
           }
           Visual.btn.Text = actiefniveau.Naam + " (" + actiefniveau.Progress + "/" + actiefniveau.TijdNodig + ") " ;
           
       }

       private string DisplayString(List<Grondstof> grondstoffenNodig)
       {
           var returnstring = "";
           foreach (var grondstof in grondstoffenNodig)
           {
               returnstring += grondstof.GrondstofType + " : " + grondstof.Waarde + " ";
           }
           return returnstring;
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
           Visual.btn.Text = actiefNiveau.Naam + " (" + actiefNiveau.Progress + "/" + actiefNiveau.TijdNodig + ") " + DisplayString(actiefNiveau.grondstoffenNodig);
       }
    }
}
