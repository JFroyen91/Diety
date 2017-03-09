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
            var keuze = BepaalWaarde(0, 100);

            // probeer altijd eerst in leven te blijven
            if (honger <= 30 && voedsel > 0) return ActieLibrary.Eet(volger);
            // zoek een huis als dit uitgevonden is en de volger er nog geen heeft;
            if (HuisNiveau > 0 && volger.Huis == null) return ActieLibrary.ZoekNaarHuis(volger);
            // job specifieke acties
            if (volger.Job == Enums.Job.Geen)
            {
                return KiesGewoneVolgerActie(keuze , volger);
            }
            if (volger.Job == Enums.Job.Shamaan)
            {
               return KiesShamaanActie(volger);
            }
            return ActieLibrary.Bid(volger);
        }

        private static Actie KiesGewoneVolgerActie(int keuze, Volger volger)
        {
            var honger = volger.GetStat(Enums.Stats.Honger);
            var voedsel = volger.Geloof.GetGrondstof(Enums.Grondstoffen.Voedsel);
            var maxvoedsel = volger.Geloof.GetGrondstof(Enums.Grondstoffen.MaxVoedsel);
            var hout = volger.Geloof.GetGrondstof(Enums.Grondstoffen.Hout);
            var maxhout = volger.Geloof.GetGrondstof(Enums.Grondstoffen.MaxHout); 
            var actieveonderzoeken = volger.Geloof.Technologieen.Where(x => x.WordtOnderzocht).ToList();

            if (honger <= 70)
            {
                if (keuze >= 0 && keuze <= 20)
                {
                    if(actieveonderzoeken.Count >0)
                     return ActieLibrary.DoeOnderzoek(volger, actieveonderzoeken.ElementAt(BepaalWaarde(0,actieveonderzoeken.Count)));
                }
                if (keuze > 20 && keuze <= 40)
                {
                    if (HoutVerzamelGrootte != 0 && hout <= maxhout)
                    {
                        return ActieLibrary.ZoekNaarHout(volger);
                    }
                }
                if (voedsel < maxvoedsel)
                {
                    return ActieLibrary.ZoekNaarVoedsel(volger);
                }
            }
            if (keuze <= 50 && actieveonderzoeken.Count > 0)
                return ActieLibrary.DoeOnderzoek(volger, actieveonderzoeken.ElementAt(BepaalWaarde(0, actieveonderzoeken.Count)));
            else
                return ActieLibrary.Bid(volger);
        }

        private static Actie KiesShamaanActie(Volger volger)
        {
            var Geloof = volger.Geloof;
            
            if (Geloof.Volgers.Count(x => x.GetStat(Enums.Stats.Leven) < 100 && x.Levend) > 0 &&
                volger.GetStat(Enums.Stats.Gelovigheid) > 10)
            {
                var teGenezenVolger = Geloof.Volgers.FirstOrDefault(x => x.GetStat(Enums.Stats.Leven) < 100 && x.Levend);
                return ActieLibrary.Genees(volger, teGenezenVolger);
            }
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
