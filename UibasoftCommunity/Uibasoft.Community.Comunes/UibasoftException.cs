using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes
{
    [Serializable]
    public class UibasoftException : Exception
    {
        public UibasoftException()
        {

        }
        public UibasoftException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
        public UibasoftException(string message)
            : base(message)
        {

        }
        public UibasoftException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

    }
}
