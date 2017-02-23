using System;
using System.Collections.Generic;
using System.Linq;

using Diety.helpers;
using Diety.helpers.Library;

namespace Diety.classes
{
    public class Geloof : Helpers
    {
        public string Naam { get; set; }
        public List<Volger> Volgers { get; set; }
        public List<Grondstof> Grondstoffen { get; set; }
        public List<Technologie> AlleTechnologieen { get; set; }
        
        public Geloof()
        {
            Naam = "ik geloof in mijzelf";
            AlleTechnologieen = TechnologieLibrary.GetAllTechnologieen();
            Volgers = InitVolgers();
            InitGrondstoffen();
        }

        private void InitGrondstoffen()
        {
            Grondstoffen = new List<Grondstof>
            {
                new Grondstof { GrondstofType = Enums.Grondstoffen.Voedsel, Waarde = 5 },
                new Grondstof { GrondstofType = Enums.Grondstoffen.Gebeden, Waarde = 0 },
                new Grondstof { GrondstofType = Enums.Grondstoffen.MaxVoedsel, Waarde = 10 },
                new Grondstof { GrondstofType = Enums.Grondstoffen.PopulatieLimiet, Waarde = 0 },
                new Grondstof { GrondstofType = Enums.Grondstoffen.XP, Waarde = 0 }
            };
        }

        public List<Volger> InitVolgers()
        {
            var volgers = new List<Volger>();
            var x = 0;
            Random r = new Random();
            for (var i = 0; i < 5; i++)
            {
                var g = r.Next(0, 100);
                Volger v = new Volger
                {
                    Stats = new List<Stat>
                    {
                        new Stat(Enums.Stats.Leven, 100),
                        new Stat(Enums.Stats.Honger, 100)
                    },
                    Geslacht = g > 50 ?Enums.Geslacht.Man :Enums.Geslacht.Vrouw,
                    Geloof = this,
                    Levend = true,
                    GeloofNiveau = Enums.GeloofNiveau.Gelovige
                };
                v.Naam = v.Geslacht == Enums.Geslacht.Man
                    ? ((Enums.VolgerMan)BepaalWaarde(0, 11)) + ""
                    : ((Enums.VolgerVrouw)BepaalWaarde(0, 11)) + "";
                v.Visual = new Visual(x, 5 , v.GetStat(Enums.Stats.Leven) , v.Geslacht , v.Naam);
                volgers.Add(v);
                x += 60;
            }
            return volgers;
        }

        public void Update(List<Cost> profijt)
        {
            if (profijt == null )
                return;
            foreach (var obrengst in profijt)
            {
                Grondstoffen.FirstOrDefault(x => x.GrondstofType == obrengst.OpbrengstType).Waarde += obrengst.CostObrengstWaarde;
            }
            CheckMaximums();
        }

        private void CheckMaximums()
        {
            if(GetGrondstof(Enums.Grondstoffen.Voedsel) > GetGrondstof(Enums.Grondstoffen.MaxVoedsel) )
                SetGrondstof(Enums.Grondstoffen.Voedsel, GetGrondstof(Enums.Grondstoffen.MaxVoedsel));
        }
        public void SetGrondstof(Enums.Grondstoffen grondstof , int waarde)
        {
            Grondstoffen.FirstOrDefault(x => x.GrondstofType == grondstof).Waarde = waarde;
        }
        public int GetGrondstof( Enums.Grondstoffen grondstof )
        {
            return Grondstoffen.FirstOrDefault(x => x.GrondstofType == grondstof).Waarde;
        }
        public int VermeerderGrondstof(Enums.Grondstoffen grondstof ,int waarde)
        {
            return Grondstoffen.FirstOrDefault(x => x.GrondstofType == grondstof).Waarde+= waarde;
        }
        public int VerminderGrondstof(Enums.Grondstoffen grondstof , int waarde)
        {
            return Grondstoffen.FirstOrDefault(x => x.GrondstofType == grondstof).Waarde -= waarde;
        }
    }
}
