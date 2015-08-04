using System;
using System.Collections;
using System.Collections.Generic;

namespace _001Task2Months
{
    class MyCollection : ICollection, IEnumerator
    {
        private readonly List<Month> _elements = new List<Month>(12);
        private int _current = -1;

        public void Add(Month month)
        {
            _elements.Add(month);
        }

        public Month GetMonthByIndex(int index)
        {
            foreach (var element in _elements)
            {
                if (element.Index == index)
                {
                    return element;
                }
            }

            return null;
        }

        public List<Month> GetMothsByDays(int numberOfDays)
        {
            return _elements.FindAll(item => item.NumberOfDays == numberOfDays);
        } 

        public IEnumerator GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            _elements.CopyTo((Month[]) array, index);
        }

        public int Count
        {
            get {return _elements.Count;}
        }

        public object SyncRoot
        {
            get { return new object(); }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public bool MoveNext()
        {
            if (_current < _elements.Count)
            {
                _current++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _current = -1;
        }

        public object Current
        {
            get { return _elements[_current]; }
        }
    }
}
