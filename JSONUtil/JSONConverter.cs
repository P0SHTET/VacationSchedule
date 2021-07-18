using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;

namespace JSONUtil
{
    public static class JSONConverter<T>
    {
        private static readonly DataContractJsonSerializer _serializer = new(typeof(T));

        public static void Serialize(T obj)
        {
            if(File.Exists("data.json"))
                File.Delete("data.json");
            FileStream stream = new("data.json", FileMode.OpenOrCreate);
            _serializer.WriteObject(stream, obj);
            stream.Close();
        }

        public static T Deserialize()
        {
            FileStream stream = new("data.json", FileMode.OpenOrCreate);
            T res = (T)_serializer.ReadObject(stream);
            stream.Close();
            return res;
        }
    }
}
