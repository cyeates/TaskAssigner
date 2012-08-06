using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TaskAssigner.Domain;
using TaskAssigner.Models;
using TaskAssigner.Tests.Fakes;

namespace TaskAssigner.Tests
{

    [TestFixture]
    public class CostTests
    {
        private Ticket _ticket1;
        private Ticket _ticket2;
        private Ticket _ticket3;
        private Ticket _ticket4;
        private Developer _homer;
        private Developer _ned;
        private IList<Ticket> _tickets;
        private IList<Developer> _developers;
        private Cost _cost;

        [SetUp]
        public void SetUp()
        {
            
            var fakeData = new FakeData();
            _tickets = fakeData.GetTickets();
            _developers = fakeData.GetDevelopers();

            _cost = new Cost(_developers, _tickets);
        }


        [Test]
        public void CostIs0WhenAllTicketsMatchDeveloperPreferences()
        {

            var solution = new List<int> {1, 2, 2, 1};
           
            Assert.AreEqual(0, _cost.Calculate(solution));
            
        }

        [Test]
        public void CostIs4WhenAllTicketsDoNotMatchDeveloperPreferences()
        {
            var solution = new List<int> {2, 1, 1, 2};
            Assert.AreEqual(4, _cost.Calculate(solution));
        }
    }
}
