using System;
using System.Collections.Generic;
using Common;

namespace Problems
{
    public class ThroneProblem
    {
        // public static void Main(string[] args)
        // {
        //     var throneInheritance = new ThroneInheritance("king");
        //     throneInheritance.Birth("king", "andy");
        //     throneInheritance.Birth("king", "bob");
        //     throneInheritance.Birth("king", "catherine");
        //     throneInheritance.Birth("andy", "matthew");
        //     throneInheritance.Birth("bob", "alex");
        //     throneInheritance.Birth("bob", "asha");
        //     Console.WriteLine($"{Utility.PrintList<string>(throneInheritance.GetInheritanceOrder())}");
        //     throneInheritance.Death("bob");
        //     Console.WriteLine($"{Utility.PrintList<string>(throneInheritance.GetInheritanceOrder())}");
        // }
    }
    public class ThroneInheritance {
        private RoyalMember root;
        private Dictionary<string, RoyalMember> _map;
        public ThroneInheritance(string kingName) {
            root = new RoyalMember(kingName, true);
            _map = new Dictionary<string, RoyalMember>();
            _map[kingName] = root;
        }
        
        public void Birth(string parentName, string childName) {
            if(!_map.ContainsKey(parentName))
            {
                return;
            }
            RoyalMember parent = _map[parentName];
            RoyalMember child = new RoyalMember(childName, false);
            child.Parent = parent;
            parent.Children.Add(child);
            _map[childName] = child;
        }
        
        public void Death(string name) {
            if(!_map.ContainsKey(name))
            {
                return;
            }
            RoyalMember member = _map[name];
            member.Decease();
        }
        
        public IList<string> GetInheritanceOrder() {
            HashSet<string> order = new HashSet<string>();
            Dfs(root, order);

            return new List<string>(order);
        }

        private void Dfs(RoyalMember current, HashSet<string> order)
        {
            if(current == null)
            {
                return;
            }

            if(current.IsAlive)
            {
                order.Add(current.Name);                
            }

            foreach(RoyalMember child in current.Children)
            {
                Dfs(child, order);
            }
        }
    }

    public class RoyalMember
    {
        public List<RoyalMember> Children {get; set;}
        public RoyalMember Parent {get; set;}

        public bool IsAlive {get; set;}

        public bool IsKing {get; set;}

        public string Name {get;}
        public RoyalMember(string name, bool isKing)
        {
            Name = name;
            IsKing = isKing;
            IsAlive = true;
            Children = new List<RoyalMember>();
        }

        public void Decease()
        {
            IsAlive = false;
        }
        public override string ToString()
        {
            return $"{Name} => Child:{Children.Count}";
        }
    }
}