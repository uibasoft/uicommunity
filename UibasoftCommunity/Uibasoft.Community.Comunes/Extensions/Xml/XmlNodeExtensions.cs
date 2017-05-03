using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Uibasoft.Community.Comunes.Extensions.Xml
{
    public static class XmlNodeExtensions
    {
        public static string GetAttributeValue(this XmlNode node, string attributeName)
        {
            if (node.Attributes == null || node.Attributes.Count <= 0)
            {
                throw new ApplicationException(node.Name + " node has not " + attributeName + " attribute");
            }
            return node.Attributes[attributeName].Value;
        }
    }
}
