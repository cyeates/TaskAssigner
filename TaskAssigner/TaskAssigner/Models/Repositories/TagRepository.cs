using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskAssigner.Models.Repositories
{
    public class TagRepository
    {
        private readonly TaskAssignerContext _context;

        public TagRepository(TaskAssignerContext context)
        {
            _context = context;
        }

        public IEnumerable<Tag> GetTags()
        {
            return _context.Tags;
        } 
    }
}