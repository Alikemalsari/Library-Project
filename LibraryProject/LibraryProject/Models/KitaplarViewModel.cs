using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class KitaplarViewModel
    {
        [Key]
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public string Yazari { get; set; }
        public bool KitapStatus { get; set; }

    }
}