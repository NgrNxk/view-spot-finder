using System.Collections.Generic;

namespace ViewSpotFinder.Model
{
    public class ParsedElement : Element
    {
        public double Elevation { get; set; }
        public IList<ParsedElement> adjecent = new List<ParsedElement>();

        public ParsedElement(Element element)
            : base(element)
        {

        }

        public bool isViewSpot()
        {
            foreach (var adElem in adjecent)
            {
                if (adElem.Elevation > Elevation)
                {
                    return false;
                }
            }
            return true;
        }
    }
}