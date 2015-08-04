using System;
using System.Collections;
using System.Collections.Generic;

namespace _001Task3Relatives
{
    class MyCollection<T> : ICollection<T> where T : Relative
    {
        private T[] _elements = new T[0];

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

        public IEnumerable<T> GetRelatives(int index)
        {
            if (Contains(_elements[index]))
            {
                foreach (var relative in _elements[index].Relatives)
                {
                    Console.Write("{0}, ", relative);
                }
            }

            return null;
        }

        public T GetRelativeByBirthDate(int birthDate)
        {
            foreach (var element in _elements)
            {
                if (element.BirthDate == birthDate)
                {
                    return element;
                }
            }

            return null;
        }

        public void Add(T item)
        {
            var newElements = new T[_elements.Length + 1];
            Array.Copy(_elements, newElements, _elements.Length);
            newElements[newElements.Length - 1] = item;
            _elements = newElements;
        }

        public void Clear()
        {
            _elements = new T[0];
        }

        public bool Contains(T item)
        {
            foreach (var element in _elements)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _elements.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < _elements.Length; i++)
            {
                if (!_elements[i].Equals(item)) continue;

                var newElements = new T[_elements.Length - 1];
                Array.Copy(_elements, 0, newElements, 0, i);
                Array.Copy(_elements, i + 1, newElements, i, _elements.Length - (i + 1));
                _elements = newElements;

                return true;
            }

            return false;
        }

        public int Count
        {
            get { return _elements.Length; }
        }

        public bool IsReadOnly
        {
            get { return _elements.IsReadOnly; }
        }
    }
}
