using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Parameters
{
    public class TypeRangeParameter<TElement>
    {
        public TypeRangeParameter()
        {

        }
        public TElement From { get; set; }
        public TElement To { get; set; }
    }
}
