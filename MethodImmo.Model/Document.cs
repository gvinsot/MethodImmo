using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodImmo.Model
{
    public class Document
    {
        public long Id;
        public TypeDeDocument TypeDeDocument;
        public Dictionary<DateTime,string> Versions;
        public IQueryable<Anomalie> Anomalies;
    }
}