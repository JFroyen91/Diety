using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Diety.helpers;
using Diety.helpers.Library;

using CornerBtn = GaryPerkin.UserControls.Buttons.RoundButton;

namespace Diety.classes
{
    public class Geloof : Helpers
    {
        private object Gebruikpower;
        public string Naam { get; set; }
        public List<Volger> Volgers { get; set; }
        public List<Grondstof> Grondstoffen { get; set; }
        public List<Technologie> Technologieen { get; set; }
        public List<Power> Powers { get; set; }

        public Geloof()
        {
            Naam = "ik geloof in mijzelf";
            Technologieen = TechnologieLibrary.GetAllTechnologieen();
            Volgers = InitVolgers();
            InitGrondstoffen();
            InitPowers();
        }

        private void InitPowers()
        {
            Powers = new List<Power>
            {
                new Power
                {
                    Beschikbaar = true,
                    UnlockWaarde = 3,
                    Visual =new PowerTechVisual {
                    Toegevoegd = false,
                    btn = new CornerBtn { Text = "Tover Voedsel(3)", Size = new Size(55,55)   },
                    
                    },
                    Gebruikpower  = ActieLibrary.GeefVoedsel
                   },
               new Power
                {
                    UnlockWaarde = 50,
                    Beschikbaar = false,
                    Visual =new PowerTechVisual {
                    Toegevoegd = false,
                    btn = new CornerBtn { Text = "Spreek tot volger(50)", Size = new Size(55,55)   },
                    },
                    Gebruikpower = ActieLibrary.MaakShamaan
                   }
            };


            var y = 15;
            var x = 15;
            foreach (var p in Powers)
            {
                p.Visual.btn.Click += p.Gebruikpower;
                p.Visual.btn.Location = new Point(x, y);
                x += 55;
                if (x >= 200)
                {
                    x = 15;
                    y += 55;
                }
            }
        }

        private void InitGrondstoffen()
        {
            Grondstoffen = new List<Grondstof>
            {
                new Grondstof { GrondstofType = Enums.Grondstoffen.Voedsel, Waarde = 5 },
                new Grondstof { GrondstofType = Enums.Grondstoffen.Gebeden, Waarde = 0 },
                new Grondstof { GrondstofType = Enums.Grondstoffen.MaxVoedsel, Waarde = 10 },
                new Grondstof { GrondstofType = Enums.Grondstoffen.PopulatieLimiet, Waarde = 0 },
                new Grondstof { GrondstofType = Enums.Grondstoffen.XP, Waarde = 0 },
                new Grondstof { GrondstofType = Enums.Grondstoffen.Hout, Waarde = 0 },
                new Grondstof { GrondstofType = Enums.Grondstoffen.MaxHout, Waarde = 10 }
            };
        }

        public List<Volger> InitVolgers()
        {
            var volgers = new List<Volger>();
            var x = 16;
            Random r = new Random();
            for (var i = 0; i < 5; i++)
            {
                Volger v = new Volger(r.Next(0, 100), this, x);
                volgers.Add(v);
                x += 80;
            }
            return volgers;
        }

        public void Update(List<Cost> profijt)
        {
            if (profijt == null)
                return;
            foreach (var obrengst in profijt)
            {
                Grondstoffen.FirstOrDefault(x => x.GrondstofType == obrengst.OpbrengstType).Waarde += obrengst.CostObrengstWaarde;
            }
            CheckMaximums();
        }

        #region grondstoffen
        private void CheckMaximums()
        {
            SetGrondstof(Enums.Grondstoffen.MaxVoedsel, 10 + VoedselOpslagGrootte);
            if (GetGrondstof(Enums.Grondstoffen.Voedsel) > GetGrondstof(Enums.Grondstoffen.MaxVoedsel))
                SetGrondstof(Enums.Grondstoffen.Voedsel, GetGrondstof(Enums.Grondstoffen.MaxVoedsel));
           
        }
        public void SetGrondstof(Enums.Grondstoffen grondstof, int waarde)
        {
            Grondstoffen.FirstOrDefault(x => x.GrondstofType == grondstof).Waarde = waarde;
        }
        public int GetGrondstof(Enums.Grondstoffen grondstof)
        {
            return Grondstoffen.FirstOrDefault(x => x.GrondstofType == grondstof).Waarde;
        }
        public int VermeerderGrondstof(Enums.Grondstoffen grondstof, int waarde)
        {
            return Grondstoffen.FirstOrDefault(x => x.GrondstofType == grondstof).Waarde += waarde;
        }
        public int VerminderGrondstof(Enums.Grondstoffen grondstof, int waarde)
        {
            return Grondstoffen.FirstOrDefault(x => x.GrondstofType == grondstof).Waarde -= waarde;
        }
        #endregion
    }
}
