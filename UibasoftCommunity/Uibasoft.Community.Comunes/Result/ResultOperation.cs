using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Result
{
    public class ResultOperation
    {
        #region Constructor
        public ResultOperation()
        {
            Errors = new List<ErrorCode>();
            Messages = new List<string>();
        }
        public ResultOperation(List<ErrorCode> errors, List<string> messages)
        {
            Errors = errors ?? new List<ErrorCode>();
            Messages = messages ?? new List<string>();
        }

        #endregion

        #region Propiedades

        public List<ErrorCode> Errors { get; set; }
        public List<string> Messages { get; set; }

        public bool HasErrors => Errors.Any();
        public bool HasMessages => Messages.Any();

        #endregion
    }
}
