using System.Collections.Generic;

namespace ViewSpotFinder.Model
{
    public class Node
    {
        public int id { get; set; }
        public float x { get; set; }
        public float y { get; set; }

        public IList<int> elementIds = new List<int>();
    }
}