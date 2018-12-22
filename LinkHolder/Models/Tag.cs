using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkHolder.Models
{
    public class Tag
    {
        //public Tag()
        //{
        //    this.Links = new HashSet<Link>();
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<LinkTag> LinkTags { get; set; }
    }
}
