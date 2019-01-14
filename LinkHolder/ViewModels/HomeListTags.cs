using LinkHolder.Models;
using System.Collections.Generic;
using System.Linq;

namespace LinkHolder.ViewModels
{
    public class HomeListTags
    {
        public string Title
        {
            get
            {
                if (JoinedTags != null && JoinedTags.Count > 0)
                {
                    string returnValue = "";
                    JoinedTags.ForEach(x => returnValue += " " + x.NameTag());

                    return returnValue;
                }
                return "";
            }
        }

        public List<Tag> JoinedTags { get; set; }

        public List<Link> Links { get; set; }



    }
}
