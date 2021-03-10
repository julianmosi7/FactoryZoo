using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FactoryZoo
{
    public class AnimalFactory
    {
        private static readonly Dictionary<string, Animal> prototypes = new();

        private static void Register(string name, Animal animal) => prototypes[name] = animal;

        static AnimalFactory()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.BaseType != null
                && !x.IsAbstract
                && x.IsSubclassOf(typeof(Animal)))
                .ToList()
                .ForEach(animalType =>
                {
                    var animal = Activator.CreateInstance(animalType) as Animal;
                    string name = animalType.Name;
                    Register(name, animal);
                });
        }

        public string[] AnimalNames => prototypes.Keys.OrderBy(x => x).ToArray();

        public List<Animal> Create(string name, int amount)
        {
            List<Animal> animalList = new List<Animal>();
            if (prototypes.ContainsKey(name))
            {
                for (int i = 0; i < amount; i++)
                {
                    animalList.Add(prototypes[name].DeepCopy());
                }
                return animalList;
            }
            else
            {
                throw new ArgumentException($"Unknown type <${name}>");
            }
        }
    }
}
