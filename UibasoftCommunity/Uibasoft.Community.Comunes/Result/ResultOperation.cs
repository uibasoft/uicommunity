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
            Messages = new List<string>();
            Errors = new List<ErrorCode>();
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

        public void AddErrorRequeridParameter(string error)
        {
            Errors.Add(new ErrorCode(ErrorCode.ErrorRequeridParameter, error));           
        }
        public void AddErrorBusinessException(string error)
        {
            Errors.Add(new ErrorCode(ErrorCode.ErrorBusinessException, error));
        }
        public void AddErrorDataAcessException(string error)
        {
            Errors.Add(new ErrorCode(ErrorCode.ErrorDataAcessException, error));
        }
        public void AddError(string code, string message)
        {
            Errors.Add(new ErrorCode(code, message));
        }
        public void AddError(string code, string message, string moreInfo)
        {
            Errors.Add(new ErrorCode(code, message, moreInfo));
        }

        public bool HasErrors => Errors.Any();
        public bool HasMessages => Messages.Any();

        #endregion
    }
}
