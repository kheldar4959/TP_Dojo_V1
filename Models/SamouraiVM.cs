using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Dojo_V1.BO;

namespace TP_Dojo_V1.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }

        public int? IdSelectedArme { get; set; }
        public List<SelectListItem> Armes { get; set; } = new List<SelectListItem>();

        public List<ArtMartial> ArtsMartiaux { get; set; } = new List<ArtMartial>();
        public List<int> IdSelectedAM { get; set; } = new List<int>();
    }
}