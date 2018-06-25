using System;
using System.Linq;

namespace MoreMethodRefactorings.ReplaceMethodWithMethodObject.Bad
{
    public class SensorSuite
    {
        public int LightLevel(int input, int level, int angle)
        {
            int var1 = (input * level) + this.Offset();
            int var2 = (input * angle) + 100;
            if ((angle - var1 < 90))
            {
                var2 -= 20;
            }
            int var3 = var2 * 4;
            // more calculations
            return var3 - 3 * var1;
        }

        public int Offset()
        {
            return 0;
        }
    }
}