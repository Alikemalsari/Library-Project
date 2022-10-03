using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class KiralamaViewModel
    {
        public int KitapId { get; set; }
        public string KitabiAlan { get; set; }
        public string KitapAdi { get; set; }
        public System.DateTime IadeZamani { get; set; }

    }
}