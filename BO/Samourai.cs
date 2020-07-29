using System.Collections.Generic;
using TP_Dojo_V1.BO;

namespace BO
{
    public class Samourai : InterfaceBO
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public List <ArtMartial> ArtMartiaux { get; set; }
    }
}
