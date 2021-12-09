using System.Collections.Generic;
using ViewSpotFinder.Model;

namespace ViewSpotFinder.Business
{
    public class ParsedMesh
    {
        public IDictionary<int, Node> dNodes { get; set; } = new Dictionary<int, Node>();
        public IDictionary<int, ParsedElement> dElements { get; set; } = new Dictionary<int, ParsedElement>();

        public ParsedMesh(InputMesh mesh)
        {
            foreach (var node in mesh.nodes)
            {
                dNodes.Add(node.id, node);
            }
            foreach (var element in mesh.elements)
            {
                dElements.Add(element.id, new ParsedElement(element));
                foreach (var nodeIds in element.nodes)
                {
                    dNodes[nodeIds].elementIds.Add(element.id);
                }
            }

            foreach (var val in mesh.values)
            {
                dElements[val.element_id].Elevation = val.value;
            }

            foreach (var element in dElements)
            {
                foreach (var nodes in element.Value.nodes)
                {
                    foreach (var adjElement in dNodes[nodes].elementIds)
                    {
                        if (adjElement != element.Value.id)
                        {
                            element.Value.adjecent.Add(dElements[adjElement]);
                        }
                    }
                }
            }
        }
    }
}