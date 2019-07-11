using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TwitterBot
{
    public class XMLStorage
    {
        static bool? writeMode;
        static object rdData;
        static Stream stream;
        static long fileLength;
        static XmlSerializer xmlSerializer;
        static XmlWriter writer;
        static XmlReader reader;
        static XmlWriterSettings xmlWriterSettings = new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment };
        static XmlReaderSettings xmlReaderSettings = new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Fragment, IgnoreWhitespace = true };
        
        public XMLStorage(string xmlPath)
        {
            xmlSerializer = new XmlSerializer(typeof(object));
            if (!File.Exists(xmlPath))
            {
                stream = File.Open(xmlPath, FileMode.CreateNew, FileAccess.ReadWrite);
                XmlWriter xmlInitializer = XmlWriter.Create(stream);
                xmlInitializer.WriteStartDocument();
                xmlInitializer.WriteWhitespace(Environment.NewLine);
                xmlInitializer.Close();
            }
            else { stream = File.Open(xmlPath, FileMode.Open, FileAccess.ReadWrite); }
            writer = XmlWriter.Create(stream, xmlWriterSettings);
            reader = XmlReader.Create(stream, xmlReaderSettings);
        }
        public void Write(Object obj, bool isNewerTweets)
        {
            if(!writeMode.HasValue || writeMode == false)
            {
                if (isNewerTweets == true)
                {
                    stream.Seek(0L, SeekOrigin.Begin);
                    reader.MoveToContent();
                }
                else { stream.Seek(0L, SeekOrigin.End); }
                writer.WriteWhitespace("");
            }
            writeMode = true;
            xmlSerializer.Serialize(writer, obj);
            writer.WriteWhitespace(Environment.NewLine);
            writer.Flush();
        }
        public object Read(out bool end)
        {
            if(!writeMode.HasValue || writeMode == true)
            {
                stream.Seek(0L, SeekOrigin.Begin);
                fileLength = stream.Length;
                reader.MoveToContent();
            }
            writeMode = false;
            end = false;
            rdData = xmlSerializer.Deserialize(reader);
            if (stream.Position >= fileLength) { end = true; }
            if(end == false) { reader.MoveToContent(); }
            return rdData;
        }
    }
}
