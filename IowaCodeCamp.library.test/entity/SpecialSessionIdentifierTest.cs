using IowaCodeCamp.library.entity.session;
using NUnit.Framework;

namespace IowaCodeCamp.library.test.entity
{
    [TestFixture]
    public class SpecialSessionIdentifierTest
    {
        private SpecialSessionIdentifier sut;

        [SetUp]
        public void setUp()
        {
            sut = new SpecialSessionIdentifier();
        }

        [Test]
        public void breakfastIsSpecialSessionName()
        {
            var isSpecialChar = sut.SessionNameRequiresSpecialTreatment("Breakfast");
            Assert.IsTrue(isSpecialChar);
        }

        [Test]
        public void welcomeIsSpecialSessionName()
        {
            var isSpecialChar = sut.SessionNameRequiresSpecialTreatment("Welcome and announcements");
            Assert.IsTrue(isSpecialChar);
        }

        [Test]
        public void breakIsSpecialSessionName()
        {
            var isSpecialChar = sut.SessionNameRequiresSpecialTreatment("Break");
            Assert.IsTrue(isSpecialChar);
        }

        [Test]
        public void lunchIsSpecialSessionName()
        {
            var isSpecialChar = sut.SessionNameRequiresSpecialTreatment("Lunch");
            Assert.IsTrue(isSpecialChar);
        }

        [Test]
        public void closingIsSpecialSessionName()
        {
            var isSpecialChar = sut.SessionNameRequiresSpecialTreatment("Closing and Prizes");
            Assert.IsTrue(isSpecialChar);
        }

        [Test]
        public void normalSessionNameIsNotSpecialSessionName()
        {
            var isSpecialChar = sut.SessionNameRequiresSpecialTreatment("Working with http on the iPhone");
            Assert.IsFalse(isSpecialChar);
        }
    }
}
