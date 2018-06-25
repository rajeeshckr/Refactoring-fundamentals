using System;
using System.Linq;

namespace MoreMethodRefactorings.ComposeMethod.Bad
{
    public class CustomCollection
    {
        public bool ReadOnly { get; set; }
        private int _size;
        private object[] elements;

public void Add(object item)
{
    if (!this.ReadOnly)
    {
        int newSize = this._size + 1;
        if (newSize > elements.Length)
        {
            object[] newElements = new object[elements.Length + 10];
            for (int i = 0; i < _size; i++)
            {
                newElements[i] = elements[i];
            }
            elements = newElements;
        }
        elements[_size++] = item;
    }
}
    }
}
