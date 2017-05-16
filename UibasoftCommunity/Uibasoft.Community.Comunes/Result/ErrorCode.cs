using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Result
{
    public class ErrorCode
    {       
        public ErrorCode()
        {
            
        }
        public string Code { get; set; }
        public string Message { get; set; }
        public string MoreInfo { get; set; }
    }
}
