using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("Project2CS480.test")]
namespace Project2CS480
{
    class Tea
    {
        private const Boolean DEBUG = false;
        static void Main(string[] args)
        {
            Tea hash = new Tea();
            hash.setup();
        }


        internal bool setup()
        {
            string input = "";
            bool output = true;
            bool holder = true;

            while (holder == true)
            {
                Console.WriteLine("Would you like to Encrypt or Decrypt something? ");
                input = Console.ReadLine();
                input.ToLower();
                if (input == "encrypt")
                {
                    output = true;
                    holder = false;
                }
                else if (input == "decrypt")
                {
                    output = false;
                    holder = false;
                }
                else
                    Console.WriteLine("Enter encrypt or decrypt");
            }


            return output;

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