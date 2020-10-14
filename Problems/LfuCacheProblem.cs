using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Common;

namespace Problems
{   
    public class CacheNode : IComparable<CacheNode>, IEquatable<CacheNode>
    {
        public int Frequency {get; set;}

        public int LastUsedTime {get; set;}
        public int Key {get;}
        public int Value {get;set;}

        public CacheNode(int key, int value)
        {
            Key = key;
            Value = value;
            Frequency = 0;
        }

        public int CompareTo(CacheNode other)
        {
            if(Frequency == other.Frequency)
            {
                return  LastUsedTime- other.LastUsedTime ;
            }
            return Frequency - other.Frequency;
        }

        public bool Equals(CacheNode other)
        {
            return Key == other.Key;
        }

        public override string ToString()
        {
            return $"{{{Key} =>{Value}, f:{Frequency}, t: {LastUsedTime}}}";
        }
    }
    public class LFUCache {        
        private PriorityQueue<CacheNode> _priorityQueue;
        private Dictionary<int, CacheNode> _map;
        private int _capacity;
        private int _time ;
        public LFUCache(int capacity) {
            _capacity = capacity;
            _time =0;
            _map = new Dictionary<int, CacheNode>();
            _priorityQueue = new PriorityQueue<CacheNode>(capacity);
        }
        
        public int Get(int key) {
            _time++;            
            if(!_map.ContainsKey(key))
            {
                return -1;
            }
            CacheNode node = _map[key];
            node.Frequency++;
            node.LastUsedTime = _time;
            UpdatePriorityQueue();

            return node.Value;
        }
        
        public void Put(int key, int value) {
            _time++;            
            if(_map.ContainsKey(key))
            {
                CacheNode node = _map[key];
                node.Value = value;
                node.Frequency++;
                node.LastUsedTime = _time;
                UpdatePriorityQueue();
                
            }
            else
            {
                if(_priorityQueue.HeapSize> 0 && _priorityQueue.HeapSize >= _capacity)
                {
                    CacheNode deleteCandidate = _priorityQueue.Dequeue();
                    _map.Remove(deleteCandidate.Key);

                }

                if(_priorityQueue.HeapSize < _capacity)
                {
                    CacheNode node = new CacheNode(key, value);
                    node.Frequency = 1;
                    node.LastUsedTime = _time;
                    _map[key] = node;

                    _priorityQueue.Enqueue(node);                    
                }
            }            
        }

        private void UpdatePriorityQueue()
        {
            while(_priorityQueue.HeapSize >0)
            {
                _priorityQueue.Dequeue();
            }

            foreach(var pair in _map)
            {
                _priorityQueue.Enqueue(pair.Value);
            }
        }
    }

    // public class LfuCacheProblem{
    //     public static void Main(string[] args)
    //     {
            
    //         StringBuilder sb = new StringBuilder();
    //         LFUCache cache = new LFUCache(2);
    //         cache.Put(1, 1);
    //         cache.Put(2, 2);
    //         sb.Append(cache.Get(2)); 
    //         sb.Append("\n");
    //         sb.Append(cache.Get(1)); 
    //         cache.Put(3, 3);

    //         Console.WriteLine($"{sb.ToString()}");
    //     }
    // }
}