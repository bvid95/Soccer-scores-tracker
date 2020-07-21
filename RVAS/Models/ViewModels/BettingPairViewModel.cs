﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RVAS.Models.ViewModels
{
    public class BettingPairViewModel
    {
        [DisplayName("Matches")]
        public int[] MatchId { get; set; }
        public MultiSelectList Matches { get; set; }
    }
}