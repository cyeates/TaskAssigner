using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using TaskAssigner.Models;
using TaskAssigner.Models.Repositories;

namespace TaskAssigner.Tests
{
    [TestFixture]
    public class DeveloperServiceTests
    {
        private Mock<IDeveloperRepository> _developerRepository;
        private Developer _developer;
        private DeveloperService _developerService;
        private const int DeveloperId = 1;

        //[SetUp]
        //public void SetUp()
        //{
        //    _developer = new Developer { DeveloperId = DeveloperId };
        //    _developerRepository = new Mock<IDeveloperRepository>();
        //    _developerRepository.Setup(d => d.GetById(DeveloperId)).Returns(_developer);

        //    _developerService = new DeveloperService(_developerRepository.Object);
        //}

        //[Test]
        //public void AddTicketsFromSolutionToDevelopers()
        //{
            
        //    var solution = new List<int> {0};
        //    var tickets = new List<Ticket>
        //                      {
        //                          new Ticket {TicketId = 123}
        //                      };
        //    var developers = new List<Developer>
        //                         {
        //                             _developer
        //                         };

        //    var updatedDevelopers = _developerService.AssignTicketsToDevelopers(solution, developers, tickets);

        //    Assert.AreEqual(123, updatedDevelopers[0].Tickets[0].TicketId);
        //}
    }
}
