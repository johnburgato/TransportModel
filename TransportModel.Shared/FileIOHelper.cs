using System;
using System.IO;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;

namespace TransportModel
{
    public class FileIOHelper
    {
        public FileIOHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void saveObject(string filePath, Object o)
        {
            //SoapFormatter serializer = new SoapFormatter();
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream fs = File.OpenWrite(filePath);
            serializer.Serialize(fs, o);

            fs.Close();
        }

        public static Object loadObject(string filePath)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream fs = File.OpenRead(filePath);
            Object o = serializer.Deserialize(fs);
            return o;
        }
    }
}
