using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkHolder.Data;
using LinkHolder.Models;

namespace LinkHolder.Services
{
    public class DbTagData : ITagData
    {
        private LinkHolderDbContext _context;

        public DbTagData(LinkHolderDbContext context)
        {
            _context = context;
        }

        public Tag Add(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag;
        }

        public Tag Get(int id)
        {
            return _context.Tags.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags.OrderBy(x => x.Name);
        }
    }
}
