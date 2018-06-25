using System;
using System.Linq;

namespace MoreMethodRefactorings.ComposeMethod.Good
{
    public class CustomCollection
    {
        public bool ReadOnly { get; set; }
        private int _size;
        private object[] elements;
        private const int GROWTH_INCREMENT = 10;

        public void Add(object item)
        {
            if (this.ReadOnly)
            {
                return;
            }
            if (AtCapacity())
            {
                Grow();
            }
            AddItem(item);
        }

        private bool AtCapacity()
        {
            return _size + 1 > elements.Length;
        }

        private void Grow()
        {
            object[] newElements = new object[elements.Length + GROWTH_INCREMENT];
            for (int i = 0; i < _size; i++)
            {
                newElements[i] = elements[i];
            }
            elements = newElements;
        }

        private void AddItem(object item)
        {
            elements[_size++] = item;
        }
    }
}
