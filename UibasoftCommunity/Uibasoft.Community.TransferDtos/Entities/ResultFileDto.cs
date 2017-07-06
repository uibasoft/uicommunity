using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Community.Comunes.Result;

namespace Uibasoft.Community.TransferDtos.Entities
{
    public class ResultFileDto : ResultOperation
    {
        public ResultFileDto()
        {

        }
        public byte[] Content { get; set; }
        public string Name { get; set; }
        public List<string> TypesMime { get; set; }

    }
}
