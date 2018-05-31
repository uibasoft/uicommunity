using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Result
{
    public class ErrorCode
    {
        public const string ErrorUnknown = "ERRORUNKNOWN";
        public const string ErrorRequeridParameter = "REQUIREDPARAMETER";
        public const string ErrorServiceSecureHttps = "REQUIRE_HTTPS";
        public const string ErrorAuthentication = "AUTHENTICATION_ERROR";
        public const string ErrorBusinessException = "BUSINESS_EXCEPTION";
        public const string ErrorDataAcessException = "DATAACESS_EXCEPTION";
        public const string ErrorFrameworkException = "FRAMEWORK_EXCEPTION";
        public const string ErrorBusinessValidation = "BUSINESS_VALIDATION";
        public const string ErrorBusinessExternalExcep = "BUSINESS_EXTERNAL_EXCEPTION";


        public ErrorCode(string code, string message)
        {
            Code = code;
            Message = message;
        }
        public ErrorCode(string code, string message, string moreinfo)
        {
            Code = code;
            Message = message;
            MoreInfo = moreinfo;
        }
        public string Code { get; set; }
        public string Message { get; set; }
        public string MoreInfo { get; set; }
    }
}
