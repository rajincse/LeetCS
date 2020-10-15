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
    public class LFUCacheWithPriorityQueue {        
        private PriorityQueue<CacheNode> _priorityQueue;
        private Dictionary<int, CacheNode> _map;
        private int _capacity;
        private int _time ;
        public LFUCacheWithPriorityQueue(int capacity) {
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
    public class LFUCache {
        private Dictionary<int, LFUItem> MapKeyToItem { get; set; }
        private FrequencyNode FrequencyHead { get; set; }
        private int _capacity;
        public LFUCache(int capacity) {
            _capacity = capacity;
            MapKeyToItem = new Dictionary<int, LFUItem>();
            FrequencyHead = GetNewFrequencyNode();
        }
        
        public int Get(int key)
        {

            if (!MapKeyToItem.ContainsKey(key))
            {
                return -1;
            }

            LFUItem item = MapKeyToItem[key];

            FrequencyNode currentFreq = item.Parent;
            FrequencyNode nextFreq = currentFreq.Next;

            if (nextFreq.Equals(FrequencyHead) || nextFreq.Frequency != currentFreq.Frequency + 1)
            {
                nextFreq = GetNewNode(currentFreq.Frequency + 1, currentFreq, nextFreq);
            }

            item.Parent = nextFreq;
            nextFreq.Items.AddLast(item);

            currentFreq.Items.Remove(item);
            if (currentFreq.Items.Count == 0)
            {
                DeleteNode(currentFreq);
            }

            return item.Value;
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0)
            {
                return;
            }
            if (MapKeyToItem.ContainsKey(key))
            {
                LFUItem item = MapKeyToItem[key];
                item.Value = value;
                Get(key);
            }
            else
            {
                if (MapKeyToItem.Count == _capacity)
                {
                    FrequencyNode freq = FrequencyHead.Next;
                    int leastRecentlyUsed = freq.Items.First.Value.Key;
                    MapKeyToItem.Remove(leastRecentlyUsed);
                    freq.Items.RemoveFirst();
                    if (freq.Items.Count == 0)
                    {
                        DeleteNode(freq);
                    }
                }

                FrequencyNode nextFreq = FrequencyHead.Next;
                if (nextFreq.Frequency != 1)
                {
                    nextFreq = GetNewNode(1, FrequencyHead, nextFreq);
                }

                var lfuItem = GetNewLfuItem(key, value, nextFreq);
                nextFreq.Items.AddLast(lfuItem);
                MapKeyToItem.Add(key, lfuItem);
            }

        }
        private FrequencyNode GetNewFrequencyNode()
        {
            var freqNode = new FrequencyNode()
            {
                Frequency = 0,
                Items = new LinkedList<LFUItem>()
            };
            freqNode.Prev = freqNode;
            freqNode.Next = freqNode;
            return freqNode;
        }

        private LFUItem GetNewLfuItem(int key, int data, FrequencyNode parent)
        {
            return new LFUItem
            {
                Key = key,
                Value = data,
                Parent = parent
            };
        }

        private FrequencyNode GetNewNode(int frequency, FrequencyNode prev, FrequencyNode next)
        {
            FrequencyNode nn = GetNewFrequencyNode();
            nn.Frequency = frequency;
            nn.Prev = prev;
            nn.Next = next;
            prev.Next = nn;
            next.Prev = nn;
            return nn;
        }

        private void DeleteNode(FrequencyNode node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }
    }

    class FrequencyNode
    {
        public int Frequency { get; set; }
        public LinkedList<LFUItem> Items { get; set; } // ddl
        public FrequencyNode Prev { get; set; }
        public FrequencyNode Next { get; set; }
    }

    class LFUItem
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public FrequencyNode Parent { get; set; }
    }
    public class LfuCacheProblem{
        public static void Main(string[] args)
        {
            
            StringBuilder sb = new StringBuilder();
            LFUCache cache = new LFUCache(2);
            cache.Put(1, 1);
            
            cache.Put(2, 2);
            
            sb.Append(cache.Get(1));             
            sb.Append("\n");
            
            cache.Put(3, 3);
            
            sb.Append(cache.Get(2)); 
            sb.Append("\n");
            
            sb.Append(cache.Get(3)); 
            sb.Append("\n");
            
            cache.Put(4, 4);
            
            sb.Append(cache.Get(1)); 
            sb.Append("\n");
            
            sb.Append(cache.Get(3)); 
            sb.Append("\n");
            
            sb.Append(cache.Get(4)); 
            sb.Append("\n");
            

            Console.WriteLine($"{sb.ToString()}");
        }
    }
}