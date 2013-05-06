using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DAL
{
    public class Element : ElementShort
    {
        public byte[] Data { get; set; }
    }

    public class ElementShort
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Name { get; set; }
        public string DataText { get; set; }
        public string DataRtf { get; set; }
        public long Position { get; set; }
    }
}
