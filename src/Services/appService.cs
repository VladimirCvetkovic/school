using System;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace School
{
    public class AppService
    {
        public async Task SaveToFile(dynamic users, string mainFolder)
        {
            var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string docPath = Path.Combine(Environment.CurrentDirectory, mainFolder, "output");
            string fileName = Timestamp.ToString() + ".json";

            if (!Directory.Exists(docPath)) Directory.CreateDirectory(docPath);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName)))
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
                string jsonString = JsonSerializer.Serialize(users,options);
                await outputFile.WriteAsync(jsonString);
            }
        }

    }
}
