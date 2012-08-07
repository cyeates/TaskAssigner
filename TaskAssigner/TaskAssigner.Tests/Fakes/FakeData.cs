using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskAssigner.Models;

namespace TaskAssigner.Tests.Fakes
{
    public class FakeData
    {
        
    
        private Ticket _ticket1;
        private Ticket _ticket2;
        private Ticket _ticket3;
        private Ticket _ticket4;
        private Developer _homer;
        private Developer _ned;
        private List<Ticket> _tickets;
        private List<Developer> _developers;

       
        public FakeData()
        {


            _ticket1 = new Ticket
                           {
                               TicketId = 1,
                               Tags = new List<Tag>
                                          {
                                            new Tag{Name = "jquery"}   
                                          }
                           };
            _ticket2 = new Ticket
                           {
                               TicketId = 2,
                               Tags = new List<Tag>
                                          {
                                              new Tag{Name="database"}
                                          }
                           };
            _ticket3 = new Ticket
                           {
                               TicketId = 3,
                               Tags = new List<Tag>
                                          {
                                              new Tag{Name="asp.net-mvc"},
                                              new Tag{Name= "c#"}
                                          }
                           };
            _ticket4 = new Ticket
                {
                    TicketId = 4,
                    Tags = new List<Tag>
                               {
                                   new Tag{Name="css"}
                               }
                };

            _tickets = new List<Ticket> { _ticket1, _ticket2, _ticket3, _ticket4 };



            _homer = new Developer
                {
                    DeveloperId = 1,
                    Tags = new List<Tag>
                               {
                                   new Tag{Name="jquery"},
                                   new Tag{Name = "javascript"}, 
                                   new Tag{Name="css"}
                               }
                };
            _ned = new Developer
                 {
                     DeveloperId = 2,
                     Tags = new List<Tag>
                                {
                                    new Tag{Name="c#"}, 
                                    new Tag{Name="asp.net-mvc"}, 
                                    new Tag{Name="database"}
                                }
                 };

            _developers = new List<Developer> { _homer, _ned };
        }

        public List<Developer> GetDevelopers()
        {
            return _developers;
        } 

        public List<Ticket> GetTickets()
        {
            return _tickets;
        } 

    }
}
