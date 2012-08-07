using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskAssigner.Models.Repositories
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetTags();
    }

    public class TagRepository : ITagRepository
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