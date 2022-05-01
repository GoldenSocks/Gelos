using Gelos.DataAccess.Json.Entityes;
using Newtonsoft.Json;


namespace Gelos.DataAccess.Json
{
    public class JsonContext
    {
        private readonly string _jsonDataPath;

        public JsonContext(JsonSettings jsonSettings)
        {
            _jsonDataPath = jsonSettings.JsonDataPath;
        }


        public void Serialize(IssueDto objToSerialise)
        { 
            using (StreamWriter file = File.AppendText(_jsonDataPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, objToSerialise);
                file.Write(Environment.NewLine);
            }
        }

        public List<IssueDto> Deserialize()
        {
            var file = File.ReadAllLines(_jsonDataPath);
            var issues = new List<IssueDto>();

            foreach (var issue in file)
            {
                issues.Add(JsonConvert.DeserializeObject<IssueDto>(issue));
            }

            return issues;
        }

        public void DeleteJson()
        {
            File.Delete(_jsonDataPath);
        }

        public void UpdateJson()
        {
            using (FileStream fstream = new FileStream(_jsonDataPath, FileMode.OpenOrCreate))
                Console.WriteLine("Jsonn пересоздан");

        }
    }
}