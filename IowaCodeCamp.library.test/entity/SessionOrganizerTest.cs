using System.Collections.Generic;
using IowaCodeCamp.library.entity.session;
using NUnit.Framework;

namespace IowaCodeCamp.library.test.entity
{
    [TestFixture]
    public class SessionOrganizerTest
    {
        [Test]
        public void ListOfSessionsOrderedByTime()
        {
            var sut = new SessionOrganizer();
            var sessions = buildInputSessions();

            var sortedSessions = sut.SortAndGroupSessionsByTime(sessions);

            var sessionTimes = new List<string>();
            var groups = sortedSessions.GetEnumerator();
            while (groups.MoveNext())
            {
                var group = groups.Current as Group<Session>;
                sessionTimes.Add(group.FormattedTitle);
            }

            Assert.AreEqual(sessionTimes.Count, 5);
            Assert.AreEqual(sessionTimes[0], " 9:00 AM - 10:30 AM");
            Assert.AreEqual(sessionTimes[1], " 10:30 AM - 11:00 AM");
            Assert.AreEqual(sessionTimes[2], " 11:00 AM - 12:30 PM");
            Assert.AreEqual(sessionTimes[3], " 12:30 PM - 1:30 PM");
            Assert.AreEqual(sessionTimes[4], " 1:30 PM - 3:00 PM");
        }

        private IEnumerable<Session> buildInputSessions()
        {
            var first = new Session() { time = "9:00 AM - 10:30 AM" };
            var second = new Session() { time = "10:30 AM - 11:00 AM" };
            var third = new Session() { time = "11:00 AM - 12:30 PM" };
            var fourth = new Session() { time = "12:30 PM - 1:30 PM" };
            var last = new Session() { time = "1:30 PM - 3:00 PM" };
            
            return new List<Session> { first,second,third,fourth,last };
        }
    }
}
