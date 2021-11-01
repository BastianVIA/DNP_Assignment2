using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Server.Data;

namespace Server.Persistence
{
    public class FileContext : IFileService
    {
        //public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; } 

        //private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";
 
        public FileContext()
        {
            //Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        public IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(adultsFile))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges(IList<Adult> adults)
        {
            // // storing families
            // string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            // {
            //     WriteIndented = true
            // });
            // using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            // {
            //     outputFile.Write(jsonFamilies);
            // }

            // storing persons
            Adults = adults;
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }
    }
}