namespace Project2CS480.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEncryption() {
            Tea tea = new Tea();
            Assert.AreEqual(false, tea.getIsEncrypting());

            tea.setIsEncrypting(false);
            Assert.AreEqual(false, tea.getIsEncrypting());

            tea.setIsEncrypting(true);
            Assert.AreEqual(true, tea.getIsEncrypting());
        }

        [Test]
        public void TestEncrypt()
        {
            Tea tea = new Tea();
            string key = "Hello world";
            tea.keyToBlocks(key);
            UInt32[] keyblock = new UInt32[36];
          //  keyblock = ["H","E"]
           // Assert.AreEqual(hash.keyToUintBlocks);
        }

        [Test]
        public void ConvertStringToUInt()
        {
            Tea hash = new Tea();
            Assert.AreEqual(1819043176, hash.convertStringToUInt("hello world"));
        }

        [Test]
        public void convertUIntToString()
        {
            Tea hash = new Tea();
            Assert.AreEqual("hell", hash.convertUIntToString(1819043176));
        }

        [Test]
        public void encrypt()
        {
            Tea hash = new Tea();
            
        }
    }
}