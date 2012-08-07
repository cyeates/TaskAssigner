using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using TaskAssigner.Domain;
using TaskAssigner.Models.Repositories;
using TaskAssigner.Tests.Fakes;

namespace TaskAssigner.Tests
{
    [TestFixture]
    public class RandomOptimizeTests
    {
        private Mock<IDeveloperRepository> _developerRepository;
        private Mock<ITicketRepository> _ticketRepository;
            
        [SetUp]
        public void SetUp()
        {
            _developerRepository = new Mock<IDeveloperRepository>();
            _ticketRepository = new Mock<ITicketRepository>();
        }

        [Test]
        public void RandomOptimizeReturnsSolution()
        {
            var fakeData = new FakeData();
            var tickets = fakeData.GetTickets();
            var developers = fakeData.GetDevelopers();

            _ticketRepository.Setup(t => t.GetTickets()).Returns(tickets);
            _developerRepository.Setup(d => d.GetDevelopers()).Returns(developers);

            var randomOptimize = new RandomOptimize(_developerRepository.Object, _ticketRepository.Object);
            var solution = randomOptimize.GetSolution();

        }
    }
}
