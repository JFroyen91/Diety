using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Diety.helpers;
using Diety.Properties;

namespace Diety.classes
{
    public class Volger : Helpers
    {
        public bool Levend { get; set; }
        public List<Stat> Stats { get; set; }
        public string Naam { get; set; }
        public Enums.Geslacht Geslacht { get; set; }
        public Enums.Job Job { get; set; }
        public Actie Actie { get; set; }
        public Geloof Geloof { get; set; }
        public Random Randomgen { get; set; }
        public Visual Visual { get; set; }
        public Gebouw Huis { get; set; }

        public Volger(int geslacht , Geloof geloof , int VisualX)
        {
            Stats = new List<Stat>
            {
                new Stat(Enums.Stats.Leven, 100),
                new Stat(Enums.Stats.Honger, 100),
                new Stat(Enums.Stats.Gelovigheid , 50)
            };
            Geslacht = geslacht > 50 ? Enums.Geslacht.Man : Enums.Geslacht.Vrouw;
            Geloof = geloof;
            Levend = true;
            Job = Enums.Job.Geen;
            Naam = Geslacht == Enums.Geslacht.Man
                    ? (Enums.VolgerMan)KiesWaardeTussen(0, 11) + ""
                    : (Enums.VolgerVrouw)KiesWaardeTussen(0, 11) + "";
            Visual = new Visual(VisualX, 5, GetStat(Enums.Stats.Leven), Geslacht, Naam);
           }

        public string Update()
        {
            var tekst = "";
            if (GetStat(Enums.Stats.Leven) <= 0) { Levend = false; }
            if (!Levend)
            {
                tekst += Naam + " is gestorven.";
                Visual.Images = Geslacht == Enums.Geslacht.Man ? new Image[] 
                {   Resources.man_blauw_dood,
                    Resources.man_blauw_dood,
                    Resources.man_blauw_dood,
                    Resources.man_blauw_dood} : 
                new Image[] 
                { Resources.vrouw_blauw_dood,
                    Resources.vrouw_blauw_dood,
                    Resources.vrouw_blauw_dood,
                    Resources.vrouw_blauw_dood };
                NextImage(0);
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
                if (GetStat(Enums.Stats.Gelovigheid) >= 100)
                {
                    SetStat(Enums.Stats.Gelovigheid, 100);
                }
                if (GetStat(Enums.Stats.Leven) >= 100)
                {
                    SetStat(Enums.Stats.Leven, 100);
                }
            }
            Visual.Hp = new Rectangle(Visual.Hp.Location, new Size(40 * GetStat(Enums.Stats.Leven) / 100, 10));
            Visual.Honger = new Rectangle(Visual.Honger.Location, new Size(40 * GetStat(Enums.Stats.Honger) / 100, 10));
            Visual.Gelovigheid = new Rectangle(Visual.Gelovigheid.Location, new Size(40 * GetStat(Enums.Stats.Gelovigheid) / 100, 10));
            Visual.NaamVisueel = new Label{ Location = Visual.NaamVisueel.Location , Text = Naam , Size = Visual.NaamVisueel.Size};
            return tekst;
        }

        public void NextImage(int counter)
        {
            Visual.Picture.Image = Visual.Images[counter];
            Visual.Picture.Update();
        }

        public string VoerActieUit()
        {
            if (Actie == null || Actie.Lengte <= 0) { Actie = Actie.KiesActie(this); }
            Actie.Update();
            Geloof.Update(Actie.Profijt);
            return Actie.Text;
        }
        #region stats
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
#endregion
    }

    public class Visual
    {
        public PictureBox Picture { get; set; }
        public Rectangle Hp { get; set; }
        public Rectangle Honger { get; set; }
        public Rectangle Gelovigheid { get; set; }
        public Label NaamVisueel { get; set; }
        public Image[] Images { get; set; }
        public int PictureCounter = 0;
        public PictureBox Huis { get; set; }

        public Visual(int x, int y, int lengtehp, Enums.Geslacht geslacht, string naam)
        {
            Picture = new PictureBox
            {
                Size = new Size(50, 40),
                BackgroundImageLayout = ImageLayout.Center,
                Visible = true,
                Location = new Point(x, y),

            };
            Huis = new PictureBox
            {
                Size = new Size(50, 40),
                BackgroundImageLayout = ImageLayout.Center,
                Visible = true,
                Location = new Point(x, y),

            };
            if (geslacht == Enums.Geslacht.Vrouw)
            {
                Images = new Image[]
                {
                    Resources.vrouw_blauw,
                    Resources.vrouw_blauw2,
                    Resources.vrouw_blauw,
                    Resources.vrouw_blauw3
                };
            }
            else
            {
                Images = new Image[]
                {
                    Resources.man_blauw,
                    Resources.man_blauw2,
                    Resources.man_blauw,
                    Resources.man_blauw3
                };
            }
            Picture.Image = Images[0];
            Huis.Image = Resources.Grot;
            NaamVisueel = new Label{ Location =  new Point(x + 5, y + 50) ,Size = new Size(50 , 15) , Text = naam };
            Hp = new Rectangle { Location = new Point(x + 5, y + 75), Size = new Size(40 * lengtehp / 100, 10) };
            Honger = new Rectangle { Location = new Point(x+5, y + 90), Size = new Size(40, 10) };
            Gelovigheid = new Rectangle { Location = new Point(x + 5, y + 105), Size = new Size(40, 10) };
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
