using System;

namespace Common
{
    public class PriorityQueue<T> where T: IComparable<T>, IEquatable<T>
    {
        private T[] _heap;
        public int HeapSize {get; private set;}

        private int LeftIndex(int index) => 2 * index+1;
        private int RightIndex(int index) => 2 * index+2;
        private int ParentIndex(int index) => (index -1)/2;

        public PriorityQueue(int capacity)
        {
            _heap = new T[capacity];
        }
        
        public void Enqueue(T value)
        {
            if(HeapSize >= _heap.Length)
            {
                throw new InvalidOperationException("Out of capacity");
            }
            HeapSize++;
            HeapIncreaseKey(HeapSize-1, value);
        }

        public T Dequeue()
        {
            if( HeapSize < 1)
            {
                throw new InvalidOperationException("Heap underflow");
            }
            T value = _heap[0];
            _heap[0] = _heap[HeapSize-1];
            _heap[HeapSize-1] = default(T);
            HeapSize--;
            Heapify(0);

            return value;
        }

        public void Update()
        {
            Heapify(0);
        }
        private void Heapify(int index)
        {
            int left = LeftIndex(index);
            int right = RightIndex(index);
            int exchangeCandidate = index;

            if(left< HeapSize && _heap[left].CompareTo(_heap[index]) < 0)
            {
                exchangeCandidate = left;
            }
            else if (right< HeapSize && _heap[right].CompareTo(_heap[index]) < 0){
                exchangeCandidate = right;
            }

            if(exchangeCandidate != index)
            {
                Swap(exchangeCandidate, index);
                Heapify(exchangeCandidate);
            }
        }
        
        private void HeapIncreaseKey(int index , T value)
        {            
            if(_heap[index] != null && !_heap[index].Equals(default(T)))
            {
                throw new InvalidOperationException("Heap value not default");
            }
            _heap[index] = value;

            while (index > 0 && _heap[ParentIndex(index)].CompareTo(_heap[index]) > 0)
            {
                Swap(ParentIndex(index), index);
                index = ParentIndex(index);
            }
        }

        private void Swap(int index1, int index2)
        {
            if(index1 < 0 || index1 >= _heap.Length || index2 < 0 || index2 >= _heap.Length)
            {
                throw new IndexOutOfRangeException($"Can not swap");
            }
            T temp = _heap[index1];
            _heap[index1] = _heap[index2];
            _heap[index2] = temp;
        }

        public override string ToString()
        {
            return Utility.PrintArray<T>(_heap);
        }
    }
}
