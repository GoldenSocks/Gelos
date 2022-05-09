using Gelos.DataAccess.Json.Entities;
using Newtonsoft.Json;


namespace Gelos.DataAccess.Json
{
    public class JsonContext
    {
        private readonly string _jsonDataPath;
        private readonly string _extention = ".json";

        public JsonContext(JsonSettings jsonSettings)
        {
            _jsonDataPath = jsonSettings.JsonDataPath;
        }

        public void Add(IssueDto issue)
        {
            var filePath = GetFilePath(issue.Id);

            using StreamWriter file = File.AppendText(filePath);
            Serialise(issue, file);
        }

        public IssueDto[] Get()
        {
            var files = Directory.GetFiles(_jsonDataPath);
            var issues = new List<IssueDto>();

            if (files.Length != 0)
            {
                foreach (var file in files)
                {
                    var data = File.ReadAllLines(file);
                    issues.AddRange(Deserialize(data));
                }
            }
            return issues.ToArray();
        }

        public void Delete(int id)
        {
            var filePath = GetFilePath(id);
            if (IsExists(id))
            {
                File.Delete(filePath);
            }
        }

        public void Update(IssueDto issue)
        {
            var filePath = GetFilePath(issue.Id);
            if (IsExists(issue.Id))
            {
                Delete(issue.Id);
                Add(issue);
            }
        }

        private bool IsExists(int id)
        {
            var issues = Get();
            if (issues != null)
            {
                if (issues.FirstOrDefault(issue => issue.Id == id) != null)
                {
                    return true;
                }
            }
            return false;
        }

        private static List<IssueDto> Deserialize(string[] data)
        {
            var issues = new List<IssueDto>();
            foreach (var issue in data)
            {
                issues.Add(JsonConvert.DeserializeObject<IssueDto>(issue));
            }
            return issues;
        }

        private static void Serialise(IssueDto issue, StreamWriter file)
        {
            JsonSerializer serializer = new();
            serializer.Serialize(file, issue);
            file.Write(Environment.NewLine);
        }

        private string GetFilePath(int id)
        {
            return Path.Combine(_jsonDataPath, id + _extention);
        }
    }
}