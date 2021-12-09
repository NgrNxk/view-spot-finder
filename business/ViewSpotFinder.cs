using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewSpotFinder.Business
{
    public class ViewSpotFinder : IViewSpotFinder
    {
        private ParsedMesh mesh;

        public ViewSpotFinder(ParsedMesh mesh)
        {
            this.mesh = mesh;
        }

        public IList<Model.Value> findViewSpots(int howMany)
        {
            var foundSpots = new List<Model.Value>();
            var sorted = mesh.dElements.OrderByDescending(p => p.Value.Elevation);
            foreach (var elem in sorted)
            {
                if (elem.Value.isViewSpot())
                {
                    foundSpots.Add(new Model.Value
                    {
                        element_id = elem.Key,
                        value = elem.Value.Elevation
                    });
                }
                if (foundSpots.Count == howMany)
                {
                    break;
                }
            }
            return foundSpots;
        }
    }
}