using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OutsorceSystem.Common.Helpers.Extensions
{
    public static class ObjectExtensions
    {
        public static byte[] ToByteArray(this object obj)
        {
            if (obj == null) return null;

            var bf = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                bf.Serialize(stream, obj);
                return stream.ToArray();
            }
        }
    }
}