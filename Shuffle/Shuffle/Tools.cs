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
        private const int Size = 5;

        /// <summary>
        /// Performs the Fisher-Yates shuffle on the pair of <filename,correct-order>.
        /// This allows us to shuffle the order of files while preserving where they
        /// should be to help with analyzing our correctness in the reconstruction.
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
        /// Creates a shred filename with a Globally Unique Identifier
        /// </summary>
        /// <returns></returns>
        public static string RandomizeName()
        {
            string randomSuffix = System.Guid.NewGuid().ToString();
            string newFilename = "image" + randomSuffix + ".png";
            return newFilename;
        }


        
    }
}
