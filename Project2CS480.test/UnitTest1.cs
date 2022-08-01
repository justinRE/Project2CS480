namespace Project2CS480.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSetup()
        {
            Tea hash = new Tea();
            string input = "encrypt";
            Assert.AreEqual(hash.setup(), true);
        }
    }
}