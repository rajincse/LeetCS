using System.Collections.Generic;

namespace Problems
{
    public class LruCacheProblem
    {
        public class LRUCache {
            private Dictionary<int, CacheNode> _map = new Dictionary<int, CacheNode>();
            private CacheNode _head = null;
            private CacheNode _tail = null;
            private int _maxCapacity = 0 ;
            public LRUCache(int capacity) {
                _maxCapacity = capacity;
            }
            
            public int Get(int key) {
                if(!_map.ContainsKey(key))
                {
                    return -1;
                }
                CacheNode node = _map[key];
                if(node != _head)
                {
                    RemoveFromList(node);
                    InsertAtFront(node);
                }
                return node.Value;
            }
            
            public void Put(int key, int value) {
                if(_map.ContainsKey(key))
                {
                    CacheNode node = _map[key];
                    node.Value = value;
                    RemoveFromList(node);
                    InsertAtFront(node);
                }
                else
                {
                    if(_map.Count >= _maxCapacity && _tail != null)
                    {
                        RemoveKey(_tail.Key);
                    }
                    CacheNode node = new CacheNode(key, value);
                    InsertAtFront(node);
                    _map[key] = node;
                }
            }

            private void RemoveFromList(CacheNode node)
            {
                if(node.Previous != null)
                {
                    node.Previous.Next = node.Next;
                }
                if(node.Next != null)
                {
                    node.Next.Previous = node.Previous;
                }
                if(node == _head)
                {
                    _head = node.Next;
                }
                if(node == _tail)
                {
                    _tail = node.Previous;
                }

                if(_head != null)
                {
                    _head.Previous = null;
                }

                if(_tail != null)
                {
                    _tail.Next = null;
                }
            }

            private void InsertAtFront(CacheNode node)
            {
                if(_head == null)
                {
                    _head = node;
                    _tail = node;
                    _head.Previous = null;
                    _tail.Next = null;
                }
                else
                {
                    node.Next = _head;
                    _head.Previous = node;
                    _head = node;
                    _head.Previous = null;
                }
                
            }

            private void RemoveKey(int key)
            {
                if(!_map.ContainsKey(key))
                {
                    return;
                }
                CacheNode node = _map[key];
                RemoveFromList(node);
                _map.Remove(node.Key);
            }
        } 
        public class CacheNode
        {
            public int Key {get; set;}
            public int Value {get; set;}

            public CacheNode Previous {get; set;}
            public CacheNode Next {get; set;}

            public CacheNode (int key, int val)
            {
                Key = key;
                Value = val;
            }
        }  
    }


}