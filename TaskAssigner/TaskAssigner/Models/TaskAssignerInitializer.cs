using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskAssigner.Models
{
    public class TaskAssignerInitializer : DropCreateDatabaseIfModelChanges<TaskAssignerContext>
    {
        protected override void Seed(TaskAssignerContext context)
        {
            var developers = new List<Developer>
                                 {
                                     new Developer
                                         {
                                             Name = "Homer Simpson",
                                             Tags = new List<string> {"jQuery", "JavaScript", "css"}
                                         },
                                    new Developer
                                        {
                                            Name = "Ned Flanders",
                                            Tags = new List<string> {"c#", "asp.net-mvc", "database"}
                                        }
                                 };

            var tickets = new List<Ticket>
                              {
                                  new Ticket
                                      {
                                          //TicketId = 1,
                                          Tags = new List<string> {"jQuery"}
                                      },
                                  new Ticket
                                      {
                                          //TicketId = 2,
                                          Tags = new List<string> {"database"}
                                      },
                                  new Ticket
                                      {
                                          //TicketId = 3,
                                          Tags = new List<string> {"asp.net-mvc", "c#"}
                                      },
                                  new Ticket
                                      {
                                         // TicketId = 4,
                                          Tags = new List<string> {"css"}
                                      }

                              };

            developers.ForEach(d => context.Developers.Add(d));
            tickets.ForEach(t => context.Tickets.Add(t));
        }
    }
}