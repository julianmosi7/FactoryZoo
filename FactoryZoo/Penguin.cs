using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryZoo
{
    [Serializable]
    internal class Penguin : Carnivore
    {
        public Penguin()
        {
            Species = "Penguin";
            Price = 2;
            MeatFoodAmount = 5;
        }

        public override string ToString()
        {
            return $"{Species}: {Price}€";
        }
    }
}
