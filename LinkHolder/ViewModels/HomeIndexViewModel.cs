using LinkHolder.Models;
using LinkHolder.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkHolder.ViewModels
{
    public class HomeIndexViewModel
    {
        public Link Link {get; set;}
        //public List<CheckBoxItem> AllPosibleTags { get; set; }
        public CheckBoxItem[] AllPosibleTags { get; set; }

        public bool MakeAnother { get; set; }
    }
}
