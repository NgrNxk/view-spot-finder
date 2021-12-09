using System;
using System.Collections.Generic;
using System.Text;

namespace ViewSpotFinder.Business
{
    interface IViewSpotFinder
    {
        IList<Model.Value> findViewSpots(int howMany);
    }
}
