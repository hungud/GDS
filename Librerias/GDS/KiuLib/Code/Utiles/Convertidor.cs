using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace KiuLib.Utiles
{
    internal static class Convertidor
    {
        public static string Serialize<T>(dynamic objeto)
        {
            var stringwriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stringwriter, objeto);

            var sXML = stringwriter.ToString();
            sXML =  sXML.Replace("utf-16", "utf-8");

            return sXML;
        }


        public static T Deserialize<T>(string sXML)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(sXML);

            var odSerializer = new XmlSerializer(typeof(T));
            using (XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDoc.DocumentElement))
            {
                return (T)odSerializer.Deserialize(xmlNodeReader);
            }
        }

    }
}
