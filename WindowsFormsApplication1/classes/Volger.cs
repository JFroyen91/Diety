using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Diety.helpers;
using Diety.Properties;

namespace Diety.classes
{
    public class Volger :Helpers
    {
        public bool Levend { get; set; }
        public List<Stat> Stats { get; set; }
        public string Naam { get; set; }
        public Enums.Geslacht Geslacht { get; set; }
        public Actie Actie { get; set; }
        public Geloof Geloof { get; set; }
        public Random Randomgen { get; set; }
        public Visual Visual { get; set; }
        

        public string Update()
        {
            var tekst = "";
            if (GetStat(Enums.Stats.Leven) <= 0) { Levend = false; }
            if (!Levend)
            {
                tekst += Naam + " is gestorven.";
                Visual.Picture.Image = Geslacht == Enums.Geslacht.Man ? Resources.man_blauw_dood : Resources.vrouw_blauw_dood;
                Visual.Picture.Update();
            }
            else
            {
                if (GetStat(Enums.Stats.Honger) <= 0)
                {
                    SetStat(Enums.Stats.Honger, 0);
                    VerminderStat(Enums.Stats.Leven, 35);
                    tekst += Naam + " lijdt honger ";
                }
                if (GetStat(Enums.Stats.Honger) >= 100)
                {
                    SetStat(Enums.Stats.Honger, 100);
                }
            }
            Visual.Hp = new Rectangle(Visual.Hp.Location, new Size(40 * GetStat(Enums.Stats.Leven) / 100, 10));
            Visual.Honger = new Rectangle(Visual.Honger.Location, new Size(40 * GetStat(Enums.Stats.Honger) / 100, 10));
            Visual.NaamVisueel = new Label{ Location = Visual.NaamVisueel.Location , Text = Naam , Size = Visual.NaamVisueel.Size};
            return tekst;
        }

        
        public string VoerActieUit()
        {
            if (Actie == null || Actie.Lengte <= 0) { Actie = Actie.KiesActie(this); }
            Actie.Update();
            Geloof.Update(Actie.Profijt);
            return Actie.Text;
        }

        internal void UpdateStats(List<Cost> Costs)
        {
            if (Costs == null)
                return;
            foreach (var cost in Costs)
            {
                VerminderStat(cost.CostType, cost.CostObrengstWaarde);
            }
                
            
        }

        public void SetStat(Enums.Stats stat , int waarde)
        {
            Stats.FirstOrDefault(x => x.StatType == stat).Waarde = waarde;
        }
        public int GetStat(Enums.Stats stat )
        {
            return Stats.FirstOrDefault(x => x.StatType == stat).Waarde;
        }
        public int VermeerderStat(Enums.Stats stat, int waarde)
        {
            return Stats.FirstOrDefault(x => x.StatType == stat).Waarde += waarde;
        }
        public int VerminderStat(Enums.Stats stat, int waarde)
        {
            return Stats.FirstOrDefault(x => x.StatType == stat).Waarde -= waarde;
        }
    }

    public class Visual
    {
        public PictureBox Picture { get; set; }
        public Rectangle Hp { get; set; }
        public Rectangle Honger { get; set; }
        public Label NaamVisueel { get; set; }

        public Visual(int x, int y, int lengtehp, Enums.Geslacht geslacht , string naam)
        {
            Picture = new PictureBox
            {
                Size = new Size(50, 40),
                BackgroundImageLayout = ImageLayout.Center,
                Image = Resources.man_blauw,
                Visible = true,
                Location = new Point(x, y)
            };
            if (geslacht == Enums.Geslacht.Vrouw)
                Picture.Image = Resources.vrouw_blauw;
           //Visual.Anchor = AnchorStyles.Left;
            NaamVisueel = new Label{ Location =  new Point(x + 5, y + 50) ,Size = new Size(50 , 15) , Text = naam };
            Hp = new Rectangle { Location = new Point(x + 5, y + 75), Size = new Size(40 * lengtehp / 100, 10) };
            Honger = new Rectangle { Location = new Point(x+5, y + 90), Size = new Size(40, 10) };
        }

       
    }

    public class Stat
    {
        public Enums.Stats StatType { get; set; }
        public int Waarde { get; set; }

        public Stat(Enums.Stats type, int waarde)
        {
            StatType = type;
            Waarde = waarde;
        }
    }

}
