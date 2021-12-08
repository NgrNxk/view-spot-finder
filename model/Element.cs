using System.Collections.Generic;

namespace ViewSpotFinder.Model
{
	public class Element {
		public int id { get; set; }
		public IList<int> nodes { get; set; }
	}
}
