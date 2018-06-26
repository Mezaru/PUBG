using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PUBG.Models.PUBGmodels;

namespace PUBG.Models.ViewModels
{
    public class HomeIndexVM
    {
        public Seasons Seasons { get; set; }
        public string PlayerName { get; set; }
        public Regions Regions { get; set; }
        public string SelectedRegion { get; set; }
    }
}
