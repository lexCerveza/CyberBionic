using System;
using System.Collections;
using System.Collections.Generic;

namespace _001Task4Dictionary
{
    class MyCollection<T> : IEnumerable<T> where T : WordUkrEng
    {
        private T[] _elements = new T[0];

        public void Add(T item)
        {
            var newElements = new T[_elements.Length + 1];
            Array.Copy(_elements, newElements, _elements.Length);
            newElements[newElements.Length - 1] = item;
            _elements = newElements;
        }

        public string this[int index, EnumLangMode mode]
        {
            get
            {
                if (index <= _elements.Length)
                {
                    return mode == EnumLangMode.Eng ? _elements[index].EngTranslation : _elements[index].UkrTranslation;
                }
                throw new Exception();
            }
            set { _elements[index].UkrTranslation = value;  }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in _elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
