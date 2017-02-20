using System.Collections.Generic;
using System.Linq;

using Diety.helpers;

namespace Diety.classes
{
    public class Actie : Helpers
    {
        public string Naam { get; set; }
        public string Text { get; set; }
        public int Lengte { get; set; }
        public List<Cost> Profijt { get; set; }
        public List<Cost> Cost { get; set; }
        public Volger ActieUitvoerder { get; set; }
        public void Update()
        {
            Lengte -= 1;
            ActieUitvoerder.UpdateStats(Cost);
        }

        public static Actie KiesActie(Volger volger)
        {
            var honger = volger.GetStat(Enums.Stats.Honger);
            var voedsel = volger.Geloof.GetGrondstof(Enums.Grondstoffen.Voedsel);
            var maxvoedsel = volger.Geloof.GetGrondstof(Enums.Grondstoffen.MaxVoedsel);
            var actieveonderzoeken = volger.Geloof.BeschikbareTechnologieen.Where(x => x.WordtOnderzocht).ToList();
            var keuze = BepaalWaarde(0, 100);


            if (honger <= 30 && voedsel > 0)
                return ActieLibrary.Eet(volger);
            if (honger <= 70 && voedsel <= maxvoedsel - VoedselVerzamelBonus/2)
            {

                if (keuze > 90 && voedsel > 0)
                    return ActieLibrary.Eet(volger);
                if (keuze < 20)
                {
                    if (keuze < 10 && actieveonderzoeken.Count > 0)
                        return ActieLibrary.DoeOnderzoek(volger, actieveonderzoeken.First());
                }
                return ActieLibrary.VerzamelVoedsel(volger);
            }
            if (keuze < 50 && actieveonderzoeken.Count > 0)
                return ActieLibrary.DoeOnderzoek(volger, actieveonderzoeken.First());
            return ActieLibrary.Bid(volger);
        }
    }


    public class Cost
    {
        public Enums.Stats CostType { get; set; }
        public Enums.Grondstoffen OpbrengstType { get; set; }
        public int CostObrengstWaarde { get; set; }
    }
}
