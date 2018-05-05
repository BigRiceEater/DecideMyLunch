using DecideMyLunch.ViewModels;
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
        private static string GetName(int numLetters)
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

        public static async Task AnimateResult(ResultViewModel vm)
        {
            var r = new Random((int)System.DateTime.Today.Ticks);
            await Task.Run(async () => {
                var it = r.Next(30, 40);
                for (int cycles = 0; cycles < it; ++cycles)
                {
                    vm.ShopName = GetName(r.Next(5, 10));

                    if (cycles == it - 1)
                        await Task.Delay(1250);
                    else
                        await Task.Delay((int)(cycles * cycles * 0.5) + r.Next(0, 10));
                }
            });
        }
    }
}
