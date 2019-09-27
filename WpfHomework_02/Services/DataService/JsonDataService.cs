using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using WpfHomework_02.Models;

namespace WpfHomework_02.Services.DataService
{
    public class JsonDataService : IDataService<IEnumerable<Student>>
    {
        string path = "data.json";
        public IEnumerable<Student> Load()
        {
            if (!File.Exists(path))
            {
                return new List<Student>();
            }
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<IEnumerable<Student>>(json);
        }

        public void Save(IEnumerable<Student> data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
