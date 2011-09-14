using System.Linq;
using IowaCodeCamp.library.entity.session;
using NUnit.Framework;

namespace IowaCodeCamp.library.test.entity
{
    [TestFixture]
    public class SessionDeserializerTest
    {
        private string validJson = "{\"data\":[{\"session\":\"First Session\",\"time\":\"9:00 AM - 10:30 AM\",\"desc\":\"very fun session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Chris Missal\",\"title\":\"Rockstar\",\"bio\":\"my hero\",\"img\":\"toranbillups.jpg\"}},{\"session\":\"Next Session\",\"time\":\"9:00 AM - 10:30 AM\",\"desc\":\"not a good session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Toran Billups\",\"title\":\"Dude\",\"bio\":\"good kid\"}},{\"session\":\"Last Session\",\"time\":\"9:00 AM - 10:30 AM\",\"desc\":\"final session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Keith Dahlby\",\"title\":\"Ninja\",\"bio\":\"rx ftw\"}},{\"session\":\"jQuery\",\"time\":\"11:00 AM - 12:30 PM\",\"desc\":\"jquery dudes\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Chris Missal\",\"title\":\"Rockstar\",\"bio\":\"my hero\"}},{\"session\":\"Mobile\",\"time\":\"11:00 AM - 12:30 PM\",\"desc\":\"mobile dudes\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Toran Billups\",\"title\":\"Dude\",\"bio\":\"good kid\"}},{\"session\":\"Rx\",\"time\":\"11:00 AM - 12:30 PM\",\"desc\":\"rx dudes\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Keith Dahlby\",\"title\":\"Ninja\",\"bio\":\"rx ftw\"}},{\"session\":\"Wrap it\",\"time\":\"1:30 AM - 3:00 PM\",\"desc\":\"wrap session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Chris Missal\",\"title\":\"Rockstar\",\"bio\":\"my hero\"}},{\"session\":\"Slice it\",\"time\":\"1:30 AM - 3:00 PM\",\"desc\":\"slice session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Toran Billups\",\"title\":\"Dude\",\"bio\":\"good kid\"}},{\"session\":\"Dice it\",\"time\":\"1:30 AM - 3:00 PM\",\"desc\":\"dice session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Keith Dahlby\",\"title\":\"Ninja\",\"bio\":\"rx ftw\"}}]}";

        [Test]
        public void BuildsListOfSessionsWithValidInput()
        {
            var sut = new SessionDeserializer();

            var sessions = sut.ParseSessionJsonAndReturnListOfSessions(validJson);

            Assert.AreEqual(sessions.ToList().Count, 9);
        }

        [Test]
        public void SessionsBuiltDuringDeserializationHaveCorrectValues()
        {
            var sut = new SessionDeserializer();

            var sessions = sut.ParseSessionJsonAndReturnListOfSessions(validJson);

            Assert.AreEqual(sessions.ToList()[0].session, "First Session");
            Assert.AreEqual(sessions.ToList()[0].time, "9:00 AM - 10:30 AM");
            Assert.AreEqual(sessions.ToList()[0].desc, "very fun session");
            Assert.AreEqual(sessions.ToList()[0].room, "XRB 300");
            Assert.AreEqual(sessions.ToList()[0].speaker.name, "Chris Missal");
            Assert.AreEqual(sessions.ToList()[0].speaker.title, "Rockstar");
            Assert.AreEqual(sessions.ToList()[0].speaker.bio, "my hero");
            Assert.AreEqual(sessions.ToList()[0].speaker.img, "toranbillups.jpg");
        }

        [Test]
        public void ReturnsEmptyListOfSessionsWithInValidInput()
        {
            var sut = new SessionDeserializer();
            var json = "sion\":\"First Session\",\"time\":\"9:00 AM - 10:30 AM\",\"desc\":\"very fun session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Chris Missal\",\"title\":\"Rockstar\",\"bio\":\"my hero\",\"img\":\"toranbillups.jpg\"}},{\"session\":\"Next Session\",\"time\":\"9:00 AM - 10:30 AM\",\"desc\":\"not a good session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Toran Billups\",\"title\":\"Dude\",\"bio\":\"good kid\",\"img\":\"toranbillups.jpg\"}},{\"session\":\"Last Session\",\"time\":\"9:00 AM - 10:30 AM\",\"desc\":\"final session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Keith Dahlby\",\"title\":\"Ninja\",\"bio\":\"rx ftw\"}},{\"session\":\"jQuery\",\"time\":\"11:00 AM - 12:30 PM\",\"desc\":\"jquery dudes\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Chris Missal\",\"title\":\"Rockstar\",\"bio\":\"my hero\"}},{\"session\":\"Mobile\",\"time\":\"11:00 AM - 12:30 PM\",\"desc\":\"mobile dudes\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Toran Billups\",\"title\":\"Dude\",\"bio\":\"good kid\"}},{\"session\":\"Rx\",\"time\":\"11:00 AM - 12:30 PM\",\"desc\":\"rx dudes\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Keith Dahlby\",\"title\":\"Ninja\",\"bio\":\"rx ftw\"}},{\"session\":\"Wrap it\",\"time\":\"1:30 AM - 3:00 PM\",\"desc\":\"wrap session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Chris Missal\",\"title\":\"Rockstar\",\"bio\":\"my hero\"}},{\"session\":\"Slice it\",\"time\":\"1:30 AM - 3:00 PM\",\"desc\":\"slice session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Toran Billups\",\"title\":\"Dude\",\"bio\":\"good kid\"}},{\"session\":\"Dice it\",\"time\":\"1:30 AM - 3:00 PM\",\"desc\":\"dice session\",\"room\":\"XRB 300\",\"speaker\":{\"name\":\"Keith Dahlby\",\"title\":\"Ninja\",\"bio\":\"rx ftw\"}}]}";

            var sessions = sut.ParseSessionJsonAndReturnListOfSessions(json);

            Assert.AreEqual(sessions.ToList().Count, 0);
        }

        [Test]
        public void ReturnsEmptyListOfSessionsWithNullInput()
        {
            var sut = new SessionDeserializer();

            var sessions = sut.ParseSessionJsonAndReturnListOfSessions(null);

            Assert.AreEqual(sessions.ToList().Count, 0);
        }
    }
}
