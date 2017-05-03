using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Cross.IoContainer.Test.Services
{
    public class DemoService : IDemoService
    {
        public string GetDateNowUtc()
        {
            return DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
        }
    }
}
