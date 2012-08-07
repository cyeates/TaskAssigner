using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskAssigner.Models.Repositories
{
    public interface IDeveloperRepository
    {
        List<Developer> GetDevelopers();
        Developer GetById(int id);
        void Save();
    }

    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly TaskAssignerContext _context;

        public DeveloperRepository(TaskAssignerContext context)
        {
            _context = context;
        }

        public List<Developer> GetDevelopers()
        {
            return _context.Developers.Include("Tags").ToList();
        }
 
        public Developer GetById(int id)
        {
            return _context.Developers.FirstOrDefault(d => d.DeveloperId == id);
        } 

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}