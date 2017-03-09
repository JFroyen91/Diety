using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Diety.classes;
using Diety.Properties;

namespace Diety.helpers
{
    public class ActieLibrary : Helpers
    {
        #region volgerActies
        #region algemeen
        public static Actie Bid(Volger volger)
        {
            var geloofpower = 1;
            if (volger.Job == Enums.Job.Shamaan)
                geloofpower = BepaalWaarde(2, 5);
            return new Actie
            {
                Lengte = 1,
                Naam = "Bid",
                Text = volger.Naam + " Bidt tot jou. (+"+geloofpower+")",
                Profijt = new List<Cost>
                {
                    new Cost { OpbrengstType = Enums.Grondstoffen.Gebeden, CostObrengstWaarde = geloofpower },
                },
                Cost = new List<Cost>
                {
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = BepaalWaarde(1,20) },
                     new Cost { CostType = Enums.Stats.Gelovigheid, CostObrengstWaarde = -geloofpower }
                },
                ActieUitvoerder = volger
            };
        }
        public static Actie Eet(Volger volger)
        {
            var actie = new Actie
            {
                Lengte = 1,
                Naam = "Eten",
                Text = volger.Naam + " Eet voedsel.",
                Profijt = new List<Cost>
                {
                    new Cost { OpbrengstType = Enums.Grondstoffen.Voedsel, CostObrengstWaarde = -1 },
                },
                Cost = new List<Cost>
                {
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = -1*BepaalWaarde(25,100) }
                },
                ActieUitvoerder = volger
            };
            return actie;
        }
        public static Actie ZoekNaarHuis(Volger volger)
        {
            bool gelukt = BepaalWaarde(0, 100) > 50;
            var returnActie = new Actie
            {
                Lengte = 1,
                Naam = "Huis zoeken",
                Profijt = new List<Cost> { },
                Cost = new List<Cost>
                {
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = 5 }
                },
                Text = gelukt ? volger.Naam + " heeft een woonplaats gevonden" : volger.Naam + "kon geen goede woonplaats vinden",
                ActieUitvoerder = volger
            };
            if(gelukt)
                switch (HuisNiveau)
                {
                    case 1 : 
                        volger.Huis = new Gebouw{Naam = "woonplaats" , Gebouwlevel = new List<Niveau>{new Niveau{Naam = "Grot"}}};
                        break;
                    default:
                        break;
                }
            return returnActie;
        }
        // to add
        public static Actie Niets(Volger volger)
        {
            return null;
        }
        public static Actie Vecht(Volger volger)
        {
            return null;
        }

        #endregion
        #region gewone volger

       
        public static Actie ZoekNaarVoedsel(Volger volger)
        {
            var opbrengstwaarde = BepaalWaarde(0+VoedselVerzamelKans,100) >50 ? BepaalWaarde(0, 2 + VoedselVerzamelGrootte) : 0;
            
            var costwaarde = BepaalWaarde(10,20);
            var actie = new Actie
            {

                Lengte = 1,
                Naam = "Voedsel Verzamelen",
                Profijt = new List<Cost>
                {
                    new Cost { OpbrengstType = Enums.Grondstoffen.Voedsel, CostObrengstWaarde = opbrengstwaarde },
                    new Cost { OpbrengstType = Enums.Grondstoffen.XP, CostObrengstWaarde = 1 },
                },
                Cost = new List<Cost>
                {
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = costwaarde }
                },
                Text = volger.Naam + " zoekt voedsel en heeft " + opbrengstwaarde + " voedsel verzameld",
                ActieUitvoerder = volger
            };
            return actie;
        }
        public static Actie ZoekNaarHout(Volger volger)
        {
            var opbrengstwaarde = BepaalWaarde(0 , 100) > 50 ? BepaalWaarde(0, 1 +  HoutVerzamelGrootte) : 0;

            var costwaarde = BepaalWaarde(15, 25);
            var actie = new Actie
            {

                Lengte = 1,
                Naam = "Hout Verzamelen",
                Profijt = new List<Cost>
                {
                    new Cost { OpbrengstType = Enums.Grondstoffen.Hout, CostObrengstWaarde = opbrengstwaarde },
                    new Cost { OpbrengstType = Enums.Grondstoffen.XP, CostObrengstWaarde = 1 },
                },
                Cost = new List<Cost>
                {
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = costwaarde }
                },
                Text = volger.Naam + " zoekt Hout en heeft " + opbrengstwaarde + " voedsel verzameld",
                ActieUitvoerder = volger
            };
            return actie;
        }      
        public static Actie DoeOnderzoek(Volger volger, Technologie tech)
        {
            var actie = new Actie
            {
                Lengte = 1,
                Naam = "Onderzoeken",
                Text = volger.Naam + " doet onderzoek naar " + tech.getActiefNiveau().Naam,
                Cost = new List<Cost>
                {
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = BepaalWaarde(10,30) },
                    new Cost { CostType = Enums.Stats.Gelovigheid, CostObrengstWaarde = BepaalWaarde(1,5) }
                },
                ActieUitvoerder = volger
            };
            tech.Onderzoek(1);
            return actie;
        }
        public static Actie BouwGebouw(Volger volger, Gebouw gebouw)
        {
            var actie = new Actie
            {
                Lengte = 1,
                Naam = "Bouwen",
                Text = volger.Naam + " doet onderzoek naar " + gebouw.Naam,
                Cost = new List<Cost>
                {
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = -1*BepaalWaarde(0,15) }
                },
                ActieUitvoerder = volger
            };
            return actie;
        }
#endregion
        #region Shamaan
        public static Actie Genees(Volger volger, Volger teGenezenVolger)
        {
            teGenezenVolger.VermeerderStat(Enums.Stats.Leven, 25);
            return new Actie
            {
                Lengte = 1,
                Naam = "Genees",
                Text = volger.Naam + " heeft "+ teGenezenVolger.Naam + " genezen" ,
                Cost = new List<Cost>
                {
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = BepaalWaarde(1,10) },
                     new Cost { CostType = Enums.Stats.Gelovigheid, CostObrengstWaarde = BepaalWaarde(10,10) },
                },

                ActieUitvoerder = volger
            };
        }
#endregion
        #region Jager
        // to add
        public static Actie Jaag(Volger volger)
        {
            return null;
        }
        public static Actie Vis(Volger volger)
        {
            return null;
        }
#endregion
        #region Boer
        // to add
        public static Actie Zaai(Volger volger)
        {
            return null;
        }
        #endregion
        #endregion
        #region GodActies

        public static void MaakShamaan(object sender, EventArgs e)
        {
            var returnstring = "je hebt niet genoeg kracht";
            if (MijnGeloof.GetGrondstof(Enums.Grondstoffen.Gebeden) >= 50)
            {
                returnstring = "je geloof is niet sterk genoeg voor nog een shamaan";
                var MeestGelovige = MijnGeloof.Volgers.Where(x=> x.Levend).OrderBy(x => x.GetStat(Enums.Stats.Gelovigheid)).Last();
                if (MeestGelovige != null && MijnGeloof.Volgers.Count(x => x.Job == Enums.Job.Shamaan) == 0)
                {
                    MeestGelovige.Job = Enums.Job.Shamaan;
                    MeestGelovige.Visual.Images = new Image[]
                    {
                        Resources.shamaan_blauw,
                        Resources.shamaan_blauw1,
                        Resources.shamaan_blauw2,
                        Resources.shamaan_blauw3
                    };
                    MijnGeloof.VerminderGrondstof(Enums.Grondstoffen.Gebeden, 50);
                   returnstring = MeestGelovige.Naam + " Heeft gesproken met de goden en is to shamaan gekroond ";
                }
              
            }
            spel.UpdateEvents(null, returnstring, Color.Blue);
        }

        public static void GeefVoedsel(object sender, EventArgs e)
        {
            var returnstring = " je hebt niet genoeg kracht";
            var waarde = BepaalWaarde(1, 3);
            if (MijnGeloof.GetGrondstof(Enums.Grondstoffen.Gebeden) >= 3 && MijnGeloof.GetGrondstof(Enums.Grondstoffen.Voedsel) < MijnGeloof.GetGrondstof(Enums.Grondstoffen.MaxVoedsel))
            {
                MijnGeloof.VerminderGrondstof(Enums.Grondstoffen.Gebeden, 3);
                MijnGeloof.VermeerderGrondstof(Enums.Grondstoffen.Voedsel, waarde);
                returnstring = "Er is " + waarde + " Voedsel verschenen";
            }
            spel.UpdateEvents(null, returnstring, Color.Blue);
            spel.UpdateLabels(MijnGeloof, false);
        }

        #endregion

      
    }
}
