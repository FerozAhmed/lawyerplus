using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetLow
{
    public class Leaf
    {
        public long id;
        public long? parent_id;
        public string parent_site_id;
        public string site_id;
        public string Name;
        public List<Leaf> Nodes;

        public Leaf()
        {
            Nodes = new List<Leaf>();
            parent_id = null;
        }
    }
}
