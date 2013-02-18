using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;


namespace Shuffle
{
    class Tools
    {

        private static readonly Random RandomNumber = new Random();
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const int Size = 5;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shreds"></param>
        /// <returns></returns>
        public static List<Tuple<string,int>> Shuffle(List<string> shreds)
        {
            var pair;
            List<Tuple<string,int>> orderedPair = new List<Tuple<string, int>>();
            for (int ii=0; ii<shreds.Count; ii++ )
            {
                pair = Tuple.Create(shreds[ii], ii);
                orderedPair.Add(pair);
                var swapNumber = RandomNumber.Next(0, shreds.Count-1);
                ExtensionMethods.Swap(orderedPair, ii, swapNumber);
            }
            return orderedPair;

        }

        /// <summary>
        /// Creates a shred filename with 5 randoms characters appended to the end
        /// </summary>
        /// <returns></returns>
        public static string RandomizeName()
        {
            /*char[] buffer = new char[Size];
            for(int ii=0; ii<Size; ii++)
            {
                buffer[ii] = Alphabet[RandomNumber.Next(Alphabet.Length)];
            }
            string randomSuffix = new string(buffer);*/
            string randomSuffix = System.Guid.NewGuid().ToString();
            string newFilename = "image" + randomSuffix + ".png";
            return newFilename;
        }


        
    }
}
