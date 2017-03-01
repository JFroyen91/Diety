using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diety.classes;
using Diety.Properties;

namespace Diety.helpers
{
    public class ActieLibrary : Helpers
    {
        #region volgerActies

        public static Actie Bid(Volger volger)
        {
            var geloofpower = 1;
            if (volger.Job == Enums.Job.Shamaan)
                geloofpower = BepaalWaarde(2, 10);
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
                     new Cost { CostType = Enums.Stats.Gelovigheid, CostObrengstWaarde = -BepaalWaarde(1,1) }
                },
                ActieUitvoerder = volger
            };
        }
        public static Actie VerzamelVoedsel(Volger volger)
        {
            var opbrengstwaarde = BepaalWaarde(0+VoedselVerzamelKans,100) >50 ? BepaalWaarde(0, 2 + VoedselVerzamelGrootte) : 0;
            
            var costwaarde = BepaalWaarde(10,30);
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
                    new Cost { CostType = Enums.Stats.Gelovigheid, CostObrengstWaarde = BepaalWaarde(1,1) }
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

        public static Actie Genees(Volger volger, Volger teGenezenVolger)
        {
            teGenezenVolger.SetStat(Enums.Stats.Leven, 100);
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
