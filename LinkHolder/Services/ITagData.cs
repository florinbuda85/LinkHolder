using LinkHolder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkHolder.Services
{
    public interface ITagData
    {
        IEnumerable<Tag> GetAll();
        Tag Get(int id);
        Tag Add(Tag tag);
    }
}
