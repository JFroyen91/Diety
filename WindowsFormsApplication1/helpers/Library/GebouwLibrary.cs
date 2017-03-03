using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diety.classes;

namespace Diety.helpers.Library
{
  public  class GebouwLibrary
    {
      public static Gebouw Opslagplaats()
      {
          var gebouw = new Gebouw{Naam = "Opslagplaats" , Gebouwlevel = new List<Niveau>
          {
              new Niveau{Naam = "Holle boom" , Text = "Jou Volgers slaan hun voedsel veilig op in een holle boom" ,VoorwaardenVoldaan = false , TijdNodig = 5 , 
                  grondstoffenNodig = new List<Grondstof>
                  {
                      new Grondstof{GrondstofType =Enums.Grondstoffen.Hout , Waarde = 5}
                  }
          }
          }};
          return gebouw;
      }
      public static Gebouw Huis()
      {
          var gebouw = new Gebouw
          {
              Naam = "Huis",
              Gebouwlevel = new List<Niveau>
          {
              new Niveau{Naam = "Grot" , Text = "Een Grot is gevonden" , VoorwaardenVoldaan = false , grondstoffenNodig = new List<Grondstof>{new Grondstof{GrondstofType = Enums.Grondstoffen.XP , Waarde = 100}} }
          }
          };
          return gebouw;
      }

      public static List<Gebouw> GetAllGebouwen()
      {
          return new List<Gebouw>{Opslagplaats() , Huis()};
      }
    }
}
