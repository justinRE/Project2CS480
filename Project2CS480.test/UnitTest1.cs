namespace Project2CS480.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestconvertStringToUInt()
        {
            Tea hash = new Tea();
            Assert.AreEqual(1819043176, hash.convertStringToUInt("hello world"));
        }

        [Test]
        public void TestconvertUIntToString()
        {
            Tea hash = new Tea();
            Assert.AreEqual("hell", hash.convertUIntToString(1819043176));
        }

        [Test]
        public void TestkeyPadding()
        {
            Tea hash = new Tea();
            string key = "0xAF6BABCDEF00F000FEAFAFAFACCDEF01";
            Assert.AreEqual(hash.keyPadding(key), "0xAF6BABCDEF00F000FEAFAFAFACCDEF01                                                                                              ");
        }


        [Test]
        public void TestkeyToUInt32Blocks()
        {
            Tea hash = new Tea();
            hash.keyToUInt32Blocks("0xAF6BABCDEF00F000FEAFAFAFACCDEF01                                                                                              ");
        }

        [Test]
        public void TestencryptText()
        {
            Tea tea = new Tea();
            string input = "0x01CA45670CABCDEF";
            string key = "0xAF6BABCDEF00F000FEAFAFAFACCDEF01";
            // This isn't the greatest unit test since it calls 2 other methods
            string paddedKey = tea.keyPadding(key);
            UInt32[] keyBlock = new UInt32[32];

            Console.WriteLine(tea.encryptText(input, keyBlock));
            // Assert.AreEqual(hash.keyToUintBlocks);
        }

        [Test]
        public void TestdecryptText()
        {
            Tea tea = new Tea();
            string input = "ø)bR;\u0099¡T;\u0017|ñQé\u000fémEñî2ØÂ\u008cðÁ&Åóø:3~òã\u007f\u0017\u000e>µ\u009dÎÛ\u009eR;\u0093~È'D¦\u0002Á²\u00181væäcsg\u0093©§HÇ\u001c,µ\u001a";
            string key = "0xAF6BABCDEF00F000FEAFAFAFACCDEF01";
            // This isn't the greatest unit test since it calls 2 other methods
            string paddedKey = tea.keyPadding(key);
            UInt32[] keyBlock = new UInt32[32];

            Console.WriteLine(tea.decryptText(input, keyBlock));
        }

    }
}