using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryZoo
{
    [Serializable]
    internal class Elephant : Herbivore
    {
        public double hornLength { get; set; }
        public Elephant()
        {
            Species = "Elephant";
            Price = 5;
            hornLength = 6;
            GreenFoodAmount = 500;
        }

        public override String ToString()
        {
            return $"{Species}: {Price}€, hornLength: {hornLength}";
        }
    }
}
