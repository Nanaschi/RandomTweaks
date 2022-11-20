

using System;

namespace ConsoleApplication1
{
    public static class Extensions
    {
        private static Random _random;

        static Extensions()
        {
            _random = new Random();
        }

        public static bool IsSatisfiedPercent(this float chance)
        {
            return chance >= _random.NextDouble();
        }
    }
}