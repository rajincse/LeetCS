using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Common;

namespace Problems
{
    public class LfuCacheProblem{
        public static void Main(string[] args)
        {
            // PriorityQueue<int> queue = new PriorityQueue<int>(10);
            // queue.Enqueue(10);
            // queue.Enqueue(5);
            // queue.Enqueue(7);
            // var val = queue.Dequeue();
            // Console.WriteLine($"{queue} => {val}");
            LFUCache cache = new LFUCache( 2 /* capacity */ );
            StringBuilder sb = new StringBuilder();
            cache.Put(1, 1);
            cache.Put(2, 2);
            sb.Append(cache.Get(1));       // returns 1
            sb.Append("\n");
            cache.Put(3, 3);    // evicts key 2
            sb.Append(cache.Get(2));       // returns -1 (not found)
            sb.Append("\n");
            sb.Append(cache.Get(3));       // returns 3.
            sb.Append("\n");
            cache.Put(4, 4);    // evicts key 1.
            sb.Append(cache.Get(1));       // returns -1 (not found)
            sb.Append("\n");
            sb.Append(cache.Get(3));       // returns 3
            sb.Append("\n");
            sb.Append(cache.Get(4));       // returns 4
            sb.Append("\n");

            Console.WriteLine($"{sb.ToString()}");
        }
    }
    
    public class CacheNode : IComparable<CacheNode>, IEquatable<CacheNode>
    {
        public int Frequency {get; set;}
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
            return Frequency - other.Frequency;
        }

        public bool Equals(CacheNode other)
        {
            return Key == other.Key;
        }

        public override string ToString()
        {
            return $"{{{Key} =>{Value}, f:{Frequency}}}";
        }
    }
    public class LFUCache {        
        private PriorityQueue<CacheNode> _priorityQueue;
        private Dictionary<int, CacheNode> _map;
        private int _capacity;
        public LFUCache(int capacity) {
            _capacity = capacity;
            _map = new Dictionary<int, CacheNode>();
            _priorityQueue = new PriorityQueue<CacheNode>(capacity);
        }
        
        public int Get(int key) {
            if(!_map.ContainsKey(key))
            {
                return -1;
            }
            CacheNode node = _map[key];
            node.Frequency++;
            _priorityQueue.Update();

            return node.Value;
        }
        
        public void Put(int key, int value) {
            if(_map.ContainsKey(key))
            {
                CacheNode node = _map[key];
                node.Value = value;
                node.Frequency = 1;
                _priorityQueue.Update();
                
            }
            else
            {
                CacheNode node = new CacheNode(key, value);
                node.Frequency = 1;
                _map[key] = node;
                
                if(_priorityQueue.HeapSize >= _capacity)
                {
                    CacheNode deleteCandidate = _priorityQueue.Dequeue();                
                    _map.Remove(deleteCandidate.Key);
                }

                _priorityQueue.Enqueue(node);
            }
            
        }
    }
}