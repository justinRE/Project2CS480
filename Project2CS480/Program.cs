using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("Project2CS480.test")]
namespace Project2CS480
{
    class Tea
    {
        public bool isEncrypting = false;
        private const Boolean DEBUG = false;
        static void Main(string[] args)
        {
            

            Tea tea = new Tea();
            tea.getInput();
            // input is key and data to encrypt/decrypt
            string key = tea.keyInput();
            string dataInput = tea.Datainput();
            string keyBlocks = tea.keyToBlocks(key);
            UInt32[] keyBlocksArray = tea.keyToUInt32Blocks(keyBlocks);
            if (tea.isEncrypting)
            {
                string final = tea.encryptText(dataInput, keyBlocksArray);
                Console.WriteLine(final);
            }
            else {
                string final = tea.decryptText(dataInput, keyBlocksArray);
                Console.WriteLine(final);
            }
        }

        public void setIsEncrypting(Boolean isEncrypting) {
            this.isEncrypting = isEncrypting;
        }
        public bool getIsEncrypting() {
            return this.isEncrypting;
        }

        internal bool getInput()
        {
            string input = "";

            while (true)
            {
                Console.WriteLine("Would you like to Encrypt or Decrypt something? [E/D]");
                input = Console.ReadLine();
                if ("e" == input.ToLower())
                {
                    return true;
                }
                else if ("d" == input.ToLower())
                {
                    return false;
                }
                else {
                }
            }
        }

        internal string keyInput()
        {
            string key;
            Console.WriteLine("Enter the key value: ");
            key = Console.ReadLine();
   
            return key;
        }

        internal string Datainput()
        {
            string inputData;

            Console.WriteLine("Enter the value to be ecrypted or decrypted: ");
            inputData = Console.ReadLine(); 

            return inputData;
        }

        internal string keyToBlocks(string key)
        {
            if (key.Length == 0)
                throw new ArgumentException("Key has to be 1-16 characters");


            int length = key.Length;
            if (length < 128)
            {
                length = 128 - length;
                for (int i = 0; i < length; i++)
                {
                    key = key + " ";
                }
            }
            return key;
        }

        internal UInt32[] keyToUInt32Blocks(string key)
        {
            UInt32[] keyBlocks = new UInt32[32];
            int holder = 0;
            for (int i = 0; i < key.Length; i += 4)
            {
                string parsestring = key.Substring(i, 4);
                keyBlocks[holder++] = convertStringToUInt(parsestring);
            }

            return keyBlocks;
        }

        internal string encryptText(string inputData, UInt32[] keyBlocks)
        {

            if (inputData.Length % 2 != 0) inputData += '\0'; // Makes sure array is even so it can be input into the encryption algorithm (uses pairs of data)
            byte[] dataBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(inputData);

            string cipher = string.Empty;
            uint[] tempData = new uint[2];
            for (int i = 0; i < dataBytes.Length; i += 2)
            {
                tempData[0] = dataBytes[i];
                tempData[1] = dataBytes[i + 1];
                encrypt(tempData, keyBlocks);
                cipher += convertUIntToString(tempData[0]) +
                                  convertUIntToString(tempData[1]);
            }

            return cipher;
        }


        public string decryptText(string inputData, UInt32[] keyBlocks)
        {
            int x = 0;
            uint[] temp = new uint[2];
            byte[] dataBytes = new byte[inputData.Length / 8 * 2];
            for (int i = 0; i < inputData.Length; i += 8)
            {
                temp[0] = convertStringToUInt(inputData.Substring(i, 4));
                temp[1] = convertStringToUInt(inputData.Substring(i + 4, 4));
                decrypt(temp, keyBlocks);
                dataBytes[x++] = (byte)temp[0];
                dataBytes[x++] = (byte)temp[1];
            }

            string decipheredString =
                    System.Text.ASCIIEncoding.ASCII.GetString(dataBytes,
                                                              0, dataBytes.Length);

            // gets rid of the padding in the final result if it has it
            if (decipheredString[decipheredString.Length - 1] == '\0')
                decipheredString = decipheredString.Substring(0, decipheredString.Length - 1);
            return decipheredString;
        }

        internal uint convertStringToUInt(string Input)
        //the opposite of how ConvertUIntToString works, without the & so it doesn't return only one byte
        {
            uint output;
            output = ((uint)Input[0]);
            output += ((uint)Input[1] << 8);
            output += ((uint)Input[2] << 16);
            output += ((uint)Input[3] << 24);
            return output;
        }

        internal string convertUIntToString(uint Input)
         // Shifts the bits in the input to make the string UInt, & 0xFF makes it return only 1 byte(a character)- 4 bytes is 32 bits which is what a UInt32 holds and what we need for the TEA Algorithm 
        {
            System.Text.StringBuilder output = new System.Text.StringBuilder();
            output.Append((char)((Input & 0xFF)));
            output.Append((char)((Input >> 8) & 0xFF));
            output.Append((char)((Input >> 16) & 0xFF));
            output.Append((char)((Input >> 24) & 0xFF));
            return output.ToString();
        }

        void encrypt(UInt32[] value, UInt32[] key)
        {
            UInt32 value0 = value[0], value1 = value[1];
            UInt32 key0 = key[0], key1 = key[1], key2 = key[2], key3 = key[3];
            UInt32 sum = 0;
            UInt32 i = 0;
            UInt32 magicNum = 0x9e3779b9;

            for (i = 0; i < 32; i++)
            {
                sum += magicNum;
                value0 += ((value1 << 4) + key0) ^ (value1 + sum) ^ ((value1 >> 5) + key1);
                value1 += ((value0 << 4) + key2) ^ (value0 + sum) ^ ((value0 >> 5) + key3);
            }

            value[0] = value0;
            value[1] = value1;
        }

        void decrypt(UInt32[] value, UInt32[] key)
        {
            UInt32 value0 = value[0], value1 = value[1];
            UInt32 key0 = key[0], key1 = key[1], key2 = key[2], key3 = key[3];
            UInt32 sum = 0xC6EF3720; //why is sum this value
            UInt32 i = 0;
            UInt32 magicNum = 0x9e3779b9;

            for (i = 0; i < 32; i++)
            {
                value1 -= ((value0 << 4) + key2) ^ (value0 + sum) ^ ((value0 >> 5) + key3);
                value0 -= ((value1 << 4) + key0) ^ (value1 + sum) ^ ((value1 >> 5) + key1);
                sum -= magicNum;
            }

            value[0] = value0;
            value[1] = value1;
        }

    }
}