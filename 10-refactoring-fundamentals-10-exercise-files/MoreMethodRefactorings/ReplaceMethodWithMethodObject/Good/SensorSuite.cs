using System;
using System.Linq;

namespace MoreMethodRefactorings.ReplaceMethodWithMethodObject.Good
{
    public class SensorSuite
    {
        public int LightLevel(int input, int level, int angle)
        {
            var lightLevel = new LightLevel(this, input, level, angle);
            return lightLevel.Compute();
        }

        public int Offset()
        {
            return 0;
        }
    }

    public class LightLevel
    {
        private readonly SensorSuite source;
        private readonly int input;
        private readonly int level;
        private readonly int angle;

        public LightLevel(SensorSuite source,
            int input, int level, int angle)
        {
            this.source = source;
            this.input = input;
            this.level = level;
            this.angle = angle;
        }

        public int Compute()
        {
            int var1 = (input * level) + source.Offset();
            int var2 = (input * angle) + 100;
            if ((angle - var1 < 90))
            {
                var2 -= 20;
            }
            int var3 = var2 * 4;
            // more calculations
            return var3 - 3 * var1;
        }
    }
}
