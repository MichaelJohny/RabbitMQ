using Newtonsoft.Json;
using System.Text;

namespace RabbitMQ
{
    public static class Extensions
    {
        public static byte[] ToBytes(this object obj)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
        }

        public static T ToObject<T>(this byte[] bytes)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(bytes));
        }
    }
}
