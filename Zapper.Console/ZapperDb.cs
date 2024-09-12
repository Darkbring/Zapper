using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data.Entity;
using System.Diagnostics;
using Zapper.Console.Models;

namespace Zapper.Console
{
    public class ZapperDb : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        public void WriteJson(object source, string filepath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filepath) ?? string.Empty);

            using (StreamWriter writer = File.CreateText(filepath))
            {
                var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, };

                JsonSerializer serializer = JsonSerializer.Create(settings);
                serializer.Converters.Add(new StringEnumConverter());

                serializer.Serialize(writer, source);
            }
        }

        public T FromJson<T>(FileInfo source)
        {
            T newInstance = default;

            try
            {
                using (StreamReader reader = source.OpenText())
                {
                    JsonSerializer serial = new JsonSerializer();
                    newInstance = (T)serial.Deserialize(reader, typeof(T));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return newInstance;
        }
    }
}
