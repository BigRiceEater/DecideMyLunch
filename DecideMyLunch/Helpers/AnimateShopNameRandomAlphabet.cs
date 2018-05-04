using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideMyLunch.Helpers
{
    public class AnimateShopNameRandomAlphabet
    {
        private static Random r = new Random((int)System.DateTime.Today.Ticks);
        public static string GetName(int numLetters)
        {
            var result = "";

            for (int i = 0; i < numLetters; ++i)
            {
                var jump = r.Next(0, 26);
                var letter = (char)('a' + jump);
                var alphabet = "";
                var decider = r.Next(0, 2);
                var mod = decider % 2;
                if (mod == 0) alphabet = letter.ToString().ToUpper();
                else alphabet = letter.ToString();
                result += alphabet;
            }

            return result;
        }
    }
}
