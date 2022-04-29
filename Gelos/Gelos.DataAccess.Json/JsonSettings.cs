
namespace Gelos.DataAccess.Json
{
    public class JsonSettings
    {
        public JsonSettings(string jsonDataPath)
        {
            JsonDataPath = jsonDataPath;
        }
        public string JsonDataPath { get; }
    }
}
