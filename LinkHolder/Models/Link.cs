using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkHolder.Models
{
    public class Link
    {

        //public Link()
        //{
        //    this.Tags = new HashSet<Tag>();
        //}

        public int Id { get; set; }
        public string Content { get; set; }
        public String Title { get; set; }
        public int TimesClicked { get; set; }
        public DateTime? LastVisit { get; set; }

        public virtual ICollection<LinkTag> LinkTags { get; set; }
    }
}
