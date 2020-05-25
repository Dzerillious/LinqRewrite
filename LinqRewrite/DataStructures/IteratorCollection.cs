using System.Collections.Generic;

namespace LinqRewrite.DataStructures
{
    public class IteratorCollection : List<IteratorParameters>
    {
        public List<IteratorParameters> All { get; } = new List<IteratorParameters>();
        public new void Add(IteratorParameters iteratorParameters)
        {
            base.Add(iteratorParameters);
            All.Add(iteratorParameters);
        }

        public new void Clear()
        {
            base.Clear();
            All.Clear();
        }
    }
}