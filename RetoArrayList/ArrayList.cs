using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArrayList
{
    public class ArrayList<T>
    {

        public enum InsertPosition
        {
            BEFORE,
            AFTER
        }

        public class Iterator
        {

            private int currentIndex;

            public bool hasNext()
            {
                return currentIndex < lastIndex;
            }

            public T next()
            {
                return (T)elements[currentIndex++];
            }

        }

        public const int DEFAULT_SIZE = 2;
        private static Object[] elements;
        private static int lastIndex;

        /* public ArrayList() => _intField = DEFAULT_SIZE;
         public int IntProperty => _intField;
         private readonly int _intField;*/

        public ArrayList() : this(DEFAULT_SIZE) { }

        public ArrayList(int initialSize)
        {
            lastIndex = 0;
            elements = new Object[initialSize];
        }

        public void add(T element)
        {
            if (lastIndex == elements.Length)
            {
                increaseArraySize();
            }

            elements[lastIndex++] = element;
        }

        public void delete(T element)
        {

            for (int index = 0; index < lastIndex; index++)
            {
                if (elements[index].Equals(element))
                {
                    delete(index);
                    return;
                }
            }
            throw new InvalidOperationException();

        }


        public void delete(int index)
        {
            if (lastIndex - index > 0 && index >= 0)
            {
                lastIndex--;
                Array.Copy(elements, index + 1, elements, index, lastIndex - index);
            }
            throw new IndexOutOfRangeException();
        }

        public Iterator getIterator()
        {
            return new Iterator();
        }

        public int size()
        {
            return lastIndex;
        }

        public T getAt(int index)
        {
            return index < lastIndex ? (T)elements[index] : throw new IndexOutOfRangeException();
        }

        public void insert(T reference, T newStudent, InsertPosition insertPosition)
        {
            int index;
            if (lastIndex == elements.Length)
            {
                increaseArraySize();
            }
            for (index = 0; index < lastIndex; index++)
            {
                if (elements[index].Equals(reference))
                {
                    if (insertPosition.Equals(InsertPosition.BEFORE))
                    {
                        for (int j = lastIndex; j > index; j--)
                        {
                            elements[j] = elements[j - 1];
                        }
                        elements[index] = newStudent;
                    }
                    else
                    {
                        for (int j = lastIndex; j > index + 1; j--)
                        {
                            elements[j] = elements[j - 1];
                        }
                        elements[index + 1] = newStudent;
                    }
                    lastIndex++;
                    return;
                }

            }

            throw new NullReferenceException();

        }
        private void increaseArraySize()
        {
            Object[] newArray = new Object[elements.Length * 2];

            Array.Copy(elements, 0, newArray, 0, elements.Length);

            elements = newArray;
        }
    }
}
