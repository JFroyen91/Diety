using System;
using System.Collections.Generic;
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
            return new Actie
            {
                Lengte = 1,
                Naam = "Bid",
                Text = volger.Naam + " Bidt tot jou.",
                Profijt = new List<Cost>
                {
                    new Cost { OpbrengstType = Enums.Grondstoffen.Gebeden, CostObrengstWaarde = BepaalWaarde(1,1) },
                },
                Cost = new List<Cost>
                {
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = BepaalWaarde(1,20) }
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
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = -1*BepaalWaarde(25,50) }
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
                    new Cost { CostType = Enums.Stats.Honger, CostObrengstWaarde = -1*BepaalWaarde(30,30) }
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

        #region GodActies

        public static string GeefVoedsel(Geloof mijnGeloof)
        {
            var returnstring = " je hebt niet genoeg kracht";
            var waarde = BepaalWaarde(1, 3);
            if (mijnGeloof.GetGrondstof(Enums.Grondstoffen.Gebeden) >= 3 && mijnGeloof.GetGrondstof(Enums.Grondstoffen.Voedsel) < mijnGeloof.GetGrondstof(Enums.Grondstoffen.MaxVoedsel))
            {
                mijnGeloof.VerminderGrondstof(Enums.Grondstoffen.Gebeden, 3);
                mijnGeloof.VermeerderGrondstof(Enums.Grondstoffen.Voedsel, waarde);
                returnstring = "Er is " + waarde + " Voedsel verschenen";
            }
            return returnstring;
        }

        #endregion

       
    }
}
