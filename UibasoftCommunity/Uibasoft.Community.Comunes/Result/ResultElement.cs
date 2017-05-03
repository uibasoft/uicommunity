using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Result
{
    public class ResultElement<TElement> : ResultOperation
    {
        public ResultElement()
        {

        }
        public ResultElement(TElement value)
        {
            Element = value;
        }
        public TElement Element { get; set; }
    }
}
