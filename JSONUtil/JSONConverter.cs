using System.IO;
using System.Text.Json;

namespace JSONUtil
{
    public static class JSONConverter<T>
    {
        private static T _obj;
        public static async void Serialize(T obj)
        {
            using (FileStream fs = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, obj);
            }
        }

        private static async void DeserializeObject()
        {
            using (FileStream fs = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                _obj = await JsonSerializer.DeserializeAsync<T>(fs);
            }
        }

        public static T Deserialize()
        {
            DeserializeObject();
            return _obj;
        }
    }
}
