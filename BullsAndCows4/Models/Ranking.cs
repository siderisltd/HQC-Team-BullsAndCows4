namespace BullsAndCowsGame.Models
{
    using System;
    using System.Collections.Generic;

    public class Ranking<T> : IEnumerable<T>, IEnumerator<T> where T : IComparable<T>
    {
        private int maxCountOfStoredData;

        private T[] data;

        private int position = -1;

        private int count;

        public Ranking(int aMaxCountOfStoredData)
        {
            this.maxCountOfStoredData = aMaxCountOfStoredData;
            this.data = new T[this.maxCountOfStoredData];
            this.count = 0;
        }

        public Ranking()
            : this(5)
        {
        }

        public int Count
        {
            get { return this.count; }
        }

        public T Current
        {
            get
            {
                return this.data[this.position];
            }
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                return this.data[this.position];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        public void Add(T item)
        {
            if (item.CompareTo(this.data[this.maxCountOfStoredData - 1]) >= 0)
            {
                int tPointer = 0;
                while (item.CompareTo(this.data[tPointer]) < 0)
                {
                    tPointer++;
                }

                for (int i = this.maxCountOfStoredData - 1; i > tPointer; i--)
                {
                    this.data[i] = this.data[i - 1];
                }

                this.data[tPointer] = item;
                if (this.count < this.maxCountOfStoredData)
                {
                    this.count++;
                }
            }
        }

        public void Dispose()
        {
            this.Reset();
        }

        public bool MoveNext()
        {
            if (this.position < this.Count - 1)
            {
                this.position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.position = -1;
        }
    }
}
