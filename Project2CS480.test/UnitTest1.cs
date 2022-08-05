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
            Tea tea = new Tea();
            tea.setup();
            string input = "e";
            Assert.AreEqual(true, tea.isEncrypting);
        }

        [Test]
        public void TestEncrypt()
        {
            Tea tea = new Tea();
            string key = "Hello world";
            tea.keyToBlocks(key);
            UInt32[] keyblock = new UInt32[4];
          //  keyblock = ["H","E"]
           // Assert.AreEqual(hash.keyToUintBlocks);
        }

        [Test]
        public void ConvertStringToUInt()
        {
            Tea hash = new Tea();
            UInt32 output;
            string[] input = new string[4];

            //Assert.AreEqual(ConvertStringToUInt(input), true);
        }
        

    }
}