using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FactoryZoo
{
    [Serializable]
    public abstract class Animal
    {
        public string Species { get; set; }
        public double GreenFoodAmount { get; set; }
        public double MeatFoodAmount { get; set; }
        public  double Price { get; set; }

        protected Animal()
        {
            this.Species = "";
            this.GreenFoodAmount = 0;
            this.MeatFoodAmount = 0;
            this.Price = 0;
        }

        internal Animal DeepCopy()
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            var copy = (Animal)formatter.Deserialize(stream);
            stream.Close();
            return copy;
        }
    }
}
 