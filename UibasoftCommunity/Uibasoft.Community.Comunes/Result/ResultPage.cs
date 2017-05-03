using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Result
{
    public class ResultPage<TElement> : ResultOperation
    {
        public ResultPage()
        {
            Elements = new List<TElement>();
        }
        public List<TElement> Elements { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalElements { get; set; }
        public int TotalPage { get; set; }
        public int TotalFiltered { get; set; }
    }
}
