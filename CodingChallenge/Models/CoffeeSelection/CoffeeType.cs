using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models.CoffeeSelection
{
    public class CoffeeType
    {
        internal static CoffeeType ShortEspresso { get; } = new CoffeeType(0, "short espresso");
        internal static CoffeeType Latte { get; } = new CoffeeType(1, "latte");
        internal static CoffeeType FlatWhite { get; } = new CoffeeType(2, "flat white");
        internal static CoffeeType LongBlack { get; } = new CoffeeType(3, "long black");
        internal static CoffeeType Mocha { get; } = new CoffeeType(4, "mocha");
        internal static CoffeeType SuperMochacrapuCaramelCream { get; } = new CoffeeType(5, "supermochacrapucaramelcream");
        internal int Value { get; private set; }
        internal string Name { get; private set; }

        private CoffeeType(int val, string name)
        {
            Value = val;
            Name = name;
        }

        internal static string[] CoffeeTypesByName()
        {
            return new[] { "short espresso", "latte" , "flat white" , "long black", "mocha", "supermochacrapucaramelcream" };
        }

    }
}
