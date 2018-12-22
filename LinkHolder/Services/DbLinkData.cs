using LinkHolder.Data;
using LinkHolder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkHolder.Services
{
    public class DbLinkData : ILinkData
    {
        private LinkHolderDbContext _context;

        public DbLinkData(LinkHolderDbContext context)
        {
            _context = context;
        }

        public Link Add(Link Link)
        {
            _context.Links.Add(Link);
            _context.SaveChanges();
            return Link;
        }

        public Link Get(int id)
        {
            return _context.Links.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Link> GetAll()
        {
            return _context
                   .Links
                   .Include(o => o.LinkTags).ThenInclude(o=>o.Tag)
                   .OrderBy(x => x.LastVisit);
        }
    }
}
