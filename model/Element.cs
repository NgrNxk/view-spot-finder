using System.Collections.Generic;
using System.Linq;

namespace ViewSpotFinder.Model
{
	public class Element
	{
		public int id { get; set; }
		public IList<int> nodes { get; set; }

		public bool isViewSpot(Mesh mesh)
		{
			double elevation = mesh.values.First(a => a.element_id == id).value;

			foreach(var adjecent in mesh.elements.Where(p => p.nodes.Intersect(nodes).Any())) {
				if (mesh.values.First(a => a.element_id == adjecent.id).value > elevation) {
					return false;
				}
			}

			return true;
		}
	}
}
