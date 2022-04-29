using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Gelos.DataAccess.Json
{
    public class JsonContext<T>
    {
        private readonly string _jsonDataPath;

        public JsonContext(JsonSettings jsonSettings)
        {
            _jsonDataPath = jsonSettings.JsonDataPath;
        }


        public void Serialize(T objToSerialise)
        {
            using (StreamWriter file = File.AppendText(_jsonDataPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, objToSerialise);
                file.Write(Environment.NewLine);
            }
        }

        public List<T> Deserialize<T>()
        {
            var file = File.ReadAllLines(_jsonDataPath);
            var issues = new List<T>();

            foreach (var issue in file)
            {
                issues.Add(JsonConvert.DeserializeObject<T>(issue));
            }

            return issues;
        }
    }
}