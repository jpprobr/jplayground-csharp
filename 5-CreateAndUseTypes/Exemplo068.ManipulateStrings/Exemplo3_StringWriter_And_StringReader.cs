using System.Globalization;
using System.IO;
using System.Xml;

namespace Exemplo068.ManipulateStrings
{
    public static class Exemplo3_StringWriter_And_StringReader
    {
        public static void ExecutarExemplo()
        {
            // Ex 3 - StringWriter (internamente usa o StringBuilder)
            // Só serve p/ adaptar a interface do StringBuilder p/ TextWriter
            var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("price", "19.95");
                writer.WriteEndElement();
                writer.Flush();
            }
            string xml = stringWriter.ToString();

            // Ex 4 - StringReader (internamente usa o StringBuilder)
            // Só serve p/ adaptar a interface do StringBuilder p/ TextReader
            var stringReader = new StringReader(xml);
            using (XmlReader reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("price");
                decimal price = decimal.Parse(reader.ReadInnerXml(),
                new CultureInfo("en-US")); // Make sure that you read the decimal part correctly
            }
        }

    }
}
