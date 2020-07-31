using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TP_Dojo_V1.BO;

namespace BO
{
    public class Samourai : InterfaceBO
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }

        //Virtual est nécéssaire pour obtenir le lazy loading
        //Permet de modifier le nom à l'affichage
        [DisplayName("Arts Martiaux maitrisés")]
        public virtual List<ArtMartial> ArtMartiaux { get; set; } = new List<ArtMartial>();


        //Ignore Potentiel lors du mathing avec la db
        [NotMapped]
         public int Potentiel
        {
            get
            {
                int potentiel = this.Force;
                if (this.Arme != null)
                {
                    potentiel += this.Arme.Degats;
                }
                potentiel *= (this.ArtMartiaux.Count + 1);

                return potentiel;
            }
        }
    }
}
