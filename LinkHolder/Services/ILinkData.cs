using LinkHolder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkHolder.Services
{
    public interface ILinkData
    {
        IEnumerable<Link> GetAll();
        List<Link> GetAllByTag(List<int> tags);
        Link Get(int id);
        Link Add(Link link);
        Link Update(Link link);
    }
}
