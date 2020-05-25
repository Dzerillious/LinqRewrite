using System.Collections.Generic;

namespace LinqRewrite.DataStructures
{
    public class IteratorCollection : List<IteratorDesign>
    {
        public List<IteratorDesign> All { get; } = new List<IteratorDesign>();
        public new void Add(IteratorDesign iteratorDesign)
        {
            base.Add(iteratorDesign);
            All.Add(iteratorDesign);
        }

        public new void Clear()
        {
            base.Clear();
            All.Clear();
        }
    }
}