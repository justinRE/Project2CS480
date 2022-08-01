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
            bool output=true;

            Console.WriteLine("Would you like to Encrypt or Decrypt something? ");
            input = Console.ReadLine();
            input.ToLower();
            bool holder = true;

            while (holder == true)
            {
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

        }
    }
