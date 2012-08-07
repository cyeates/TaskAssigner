using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskAssigner.Models
{
    public class TaskAssignerInitializer : DropCreateDatabaseIfModelChanges<TaskAssignerContext>
    {
        
        private List<Tag> _tags;

        protected override void Seed(TaskAssignerContext context)
        {
            
            var tags = new List<string> {"c#", "vb.net", "mvc", "asp.net-mvc", "asp.net", ".net", "javascript", "jquery", "ajax", "coffeescript", "sass", "silverlight", "css", "css3", "html", "html5", "database", "sql", "linq", 
                                         "entity-framework", "oop", "ooa", "ood", "object-oriented-programming", "git", "mercurial", "hg", "subversion", "svn", "tdd", "unit-testing", "test-driven-development",
                                         "debugging", "windows-phone", "android", "iphone"};

            tags.ForEach(t => context.Tags.Add(new Tag { Name = t }));
            context.SaveChanges();

            _tags = context.Tags.ToList();

            var developers = new List<Developer>
                                 {
                                     new Developer
                                         {
                                             Name = "Homer Simpson",
                                             Tags = new List<Tag>
                                                        {
                                                            GetTagByName("jquery"), GetTagByName("javascript"), GetTagByName("css")
                                                        }
                                         },
                                    new Developer
                                        {
                                            Name = "Ned Flanders",
                                            Tags = new List<Tag>
                                                       {
                                                           GetTagByName("c#"), GetTagByName("asp.net-mvc"), GetTagByName("database")
                                                       }
                                        }
                                 };

            var tickets = new List<Ticket>
                              {
                                  new Ticket
                                      {
                                          Description = "Something about jQuery",
                                          Tags = new List<Tag> {GetTagByName("jquery")}
                                      },
                                  new Ticket
                                      {
                                          Description = "A task that involves the database",
                                          Tags = new List<Tag> {GetTagByName("database")}
                                      },
                                  new Ticket
                                      {
                                          Description = "Something to do with ASP.Net MVC and C#",
                                          Tags = new List<Tag> {GetTagByName("asp.net-mvc"), GetTagByName("c#")}
                                      },
                                  new Ticket
                                      {
                                         Description = "Some front end stuff having to do with css and html",
                                          Tags = new List<Tag> {GetTagByName("css"), GetTagByName("html")}
                                      }

                              };

            developers.ForEach(d => context.Developers.Add(d));
            tickets.ForEach(t => context.Tickets.Add(t));

            

            context.SaveChanges();
        }

        private Tag GetTagByName(string name)
        {
            var tag = _tags.FirstOrDefault(t => t.Name == name);
            return tag;
        }
    }
}