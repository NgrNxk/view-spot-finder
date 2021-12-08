using System.Collections.Generic;
using System.Linq;

namespace ViewSpotFinder.Business
{
	public class ViewSpotFinder {

		private Model.Mesh mesh;

		public ViewSpotFinder(Model.Mesh mesh) {
			this.mesh = mesh;
		}

		public IList<Model.Value> findViewSpots(int howMany) {
			var foundSpots = new List<Model.Value>();
			foreach(var elevation in mesh.values.OrderByDescending(p => p.value)) {
				var elem = mesh.elements.First(a => a.id == elevation.element_id);
				if (elem.isViewSpot(mesh)) {
					foundSpots.Add(elevation);
				}
				if (foundSpots.Count == howMany) {
					break;
				}
			}
			return foundSpots;
		}
	}
}
