using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PUBG.Models.PUBGmodels;

namespace PUBG.Models.ViewModels
{
    public class HomePlayerDetailVM
    {
        public Player Player { get; set; }
        public List<MatchObject> Matches { get; set; }
        public Seasons Seasons { get; set; }
    }
}
