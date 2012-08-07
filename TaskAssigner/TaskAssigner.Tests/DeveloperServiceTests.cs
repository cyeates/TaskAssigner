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
        private Mock<ITicketRepository> _ticketRepository;
        private Mock<OptimizationAlgorithm> _optimization;


        [SetUp]
        public void SetUp()
        {
            
            var developers = new List<Developer>
                                 {
                                    new Developer{Name = "Chad Yeates"}
                                 };

            _developerRepository = new Mock<IDeveloperRepository>();
            _developerRepository.Setup(d => d.GetDevelopers()).Returns(developers);


            var tickets = new List<Ticket>
                              {
                                  new Ticket {TicketId = 123}
                              };

            _ticketRepository = new Mock<ITicketRepository>();
            _ticketRepository.Setup(t => t.GetTickets()).Returns(tickets);

            var solution = new List<int> { 0 };
            _optimization = new Mock<OptimizationAlgorithm>();
            _optimization.Setup(o => o.GetSolution()).Returns(solution);


        }

        [Test]
        public void AddTicketsFromSolutionToDevelopers()
        {
            var developerService = new DeveloperService(_developerRepository.Object, _ticketRepository.Object, _optimization.Object);
            var updatedDevelopers = developerService.AssignTicketsToDevelopers();

            Assert.AreEqual(123, updatedDevelopers[0].Tickets[0].TicketId);
        }
    }
}
