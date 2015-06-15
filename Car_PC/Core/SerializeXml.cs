using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Car_PC.Core
{
    /// <summary>
    /// 序列号类
    /// </summary>
    public class SerializeXml
    {
        /// <summary>
        ///将对象序列化成XML
        /// </summary>
        /// <param name="e">需要进行序列化的对象.</param>
        /// <param name="t">对象的类型</param>
        /// <returns>XML文本</returns>
        public static string SerializeObjectToXML(object e, Type t)
        {
            
            XmlSerializer serilizer = new XmlSerializer(t);
            System.Text.StringBuilder sbXML = new StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sbXML);
            serilizer.Serialize(writer, e);
            writer.Close();
            sbXML = sbXML.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
            if (sbXML.ToString().IndexOf(" xmlns:xsi=") > 0)
            {
                return sbXML.ToString().Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "").Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
            }
            return sbXML.ToString();
        }

        /// <summary>
        /// 将对象序列化成XML
        /// </summary>
        /// <param name="e">需要进行序列化的对象.</param>
        /// <returns>XML文本</returns>
        public static string SerializeObjectToXML(object e)
        {
            Type t = e.GetType();
            XmlSerializer serilizer = new XmlSerializer(t);
            System.Text.StringBuilder sbXML = new StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sbXML);
            serilizer.Serialize(writer, e);
            writer.Close();
            sbXML = sbXML.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
            if (sbXML.ToString().IndexOf(" xmlns:xsi=") > 0)
            {
                return sbXML.ToString().Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            }
            return sbXML.ToString();
        }

        /// <summary>
        /// 将XML反序列化成XML
        /// </summary>
        /// <param name="xml">XML.</param>
        /// <param name="t">对象类型</param>
        /// <returns>返回对应类型对象</returns>
        public static object DeserializeGetObject(string xml, Type t)
        {
            //xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + xml;
            if (xml.IndexOf("<?xml") >= 0 )
            {
                Regex reg = new Regex(@"^\s*\S*<\?xml[^(<)]+(?<body>[\s\S]+)$");
                Match match = reg.Match(xml);
                xml = match.Groups["body"].Value;
               // xml = xml.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", string.Empty);
            }
            XmlSerializer serializer = new XmlSerializer(t);

            System.IO.StringReader reader = new System.IO.StringReader(xml);

            object f = (object)serializer.Deserialize(reader);

            return f;
        }
        /// <summary>
        /// 将XML反序列化成XML
        /// </summary>
        /// <param name="xml">XML.</param>
        /// <param name="t">对象类型</param>
        /// <returns>返回对应类型对象</returns>
        public static T DeserializeGetObject<T>(string xml)
        {
            //xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + xml;
            if (xml.IndexOf("<?xml") >= 0)
            {
                Regex reg = new Regex(@"^\s*\S*<\?xml[^(<)]+(?<body>[\s\S]+)$");
                Match match = reg.Match(xml);
                xml=match.Groups["body"].Value;
                //xml = xml.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", string.Empty);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            System.IO.StringReader reader = new System.IO.StringReader(xml);

            object f = (object)serializer.Deserialize(reader);

            return (T) f;
        }
    }
}