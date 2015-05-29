using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Engine.Collections
{
    public class RandomDistributionList<T>
    {
        private readonly List<Element> _elements = new List<Element>(); 

        public void AddElement(T item, int distributionPercentage)
        {
            _elements.Add(new Element(item, distributionPercentage));
        }

        public bool IsEmpty()
        {
            return (_elements.Count == 0);
        }

        public bool IsNotEmpty()
        {
            return !IsEmpty();
        }

        public T GetRandomElement()
        {
            int randomNumber = RandomNumberGenerator.GetNumberBetween(1, _elements.Sum(element => element.DistributionPercentage));

            int currentMax = 0;

            foreach(Element element in _elements)
            {
                currentMax += element.DistributionPercentage;

                if(randomNumber <= currentMax)
                {
                    return element.Item;
                }
            }

            return _elements.Last().Item;
        }

        private class Element
        {
            public T Item { get; private set; }
            public int DistributionPercentage { get; private set; }

            internal Element(T item, int distributionPercentage)
            {
                Item = item;
                DistributionPercentage = distributionPercentage;
            }
        }
    }
}
