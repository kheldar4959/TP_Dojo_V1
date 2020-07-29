using TP_Dojo_V1.BO;

namespace BO
{
    public class Arme : InterfaceBO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Degats { get; set; }
    }
}