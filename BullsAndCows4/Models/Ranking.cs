namespace BullsAndCowsGame.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Ranking<T> : IEnumerable<T>, IEnumerator<T> where T : IComparable<T>
    {
        private int maxCountOfStoredData;

        private T[] data;

        private int position = -1;

        private int count;

        public Ranking(int amaxCountOfStoredData)
        {
            this.maxCountOfStoredData = amaxCountOfStoredData;
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

        object IEnumerator.Current
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        public void Add(T item)
        {
            if (item.CompareTo(this.data[this.maxCountOfStoredData - 1]) >= 0)
            {
                int pointerT = 0;
                while (item.CompareTo(this.data[pointerT]) < 0)
                {
                    pointerT++;
                }

                for (int i = this.maxCountOfStoredData - 1; i > pointerT; i--)
                {
                    this.data[i] = this.data[i - 1];
                }

                this.data[pointerT] = item;
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
