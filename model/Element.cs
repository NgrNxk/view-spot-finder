using System.Collections.Generic;

namespace ViewSpotFinder.Model
{
    public class Element
    {
        public int id { get; set; }
        public IList<int> nodes { get; set; }

        public Element() { }
        public Element(Element element)
        {
            id = element.id;
            nodes = element.nodes;
        }
    }
}