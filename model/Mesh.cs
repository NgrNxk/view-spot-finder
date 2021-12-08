using System.Collections.Generic;

namespace ViewSpotFinder.Model
{
    public class Mesh
    {
		public IList<Node> nodes { get; set; }
		public IList<Element> elements { get; set; }
		public IList<Value> values { get; set; }
    }
}
