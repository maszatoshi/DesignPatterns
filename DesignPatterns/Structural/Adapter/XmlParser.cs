using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesignPatterns.Structural.Adapter
{
    public class XmlParser<T> : IXmlParser<T>
    {
        public readonly XmlSerializer _serializer;

        public XmlParser()
        {
                _serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(typeof(T).Name.ToLower()));
        }
        public string ConverToXml(T obj)
        {
            using StringWriter sw = new StringWriter();
            _serializer.Serialize(sw, obj);

            return sw.ToString();
        }

        public T Parse(string data)
        {
            using TextReader reader = new StringReader(data);
            return (T)_serializer.Deserialize(reader);
        }
    }
}
