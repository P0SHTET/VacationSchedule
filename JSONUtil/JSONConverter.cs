using System.IO;
using System.Runtime.Serialization.Json;

namespace JSONUtil
{
    public static class JSONConverter<T>
    {
        private static DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
        
        public static void Serialize(T obj)
        {
            FileStream stream = new FileStream("data.json", FileMode.OpenOrCreate);
            serializer.WriteObject(stream,obj);
            stream.Close();
        }

        public static T Deserialize()
        {
            FileStream stream = new FileStream("data.json", FileMode.OpenOrCreate);
            T res = (T)serializer.ReadObject(stream);
            stream.Close();
            return res;
        }
    }
}
