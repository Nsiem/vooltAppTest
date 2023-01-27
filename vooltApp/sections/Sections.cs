using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace vooltApp.sections
{
    public class Sections
    {
        public string Section_Id { get; set; }

        public int Order { get; set; }


        public static List<dynamic> DeserializeSections(List<string> sections)
        {
            List<dynamic> sectionModels = new List<dynamic>();
            foreach (string JsonString in sections)
            {
                JObject json = JObject.Parse(JsonString);
                string ClassType = json["ClassType"].Value<string>();
                switch (ClassType)
                {
                    case "Header":
                        Header JsonHeader = JsonConvert.DeserializeObject<Header>(JsonString);
                        sectionModels.Add(JsonHeader);
                        break;
                    case "Hero":
                        Hero JsonHero = JsonConvert.DeserializeObject<Hero>(JsonString);
                        sectionModels.Add(JsonHero);
                        break;
                    case "ItemList":
                        ItemList JsonItemList = JsonConvert.DeserializeObject<ItemList>(JsonString);
                        sectionModels.Add(JsonItemList);
                        break;
                }
            }

            return sectionModels;
        }

        public static void SerializeAndWriteToFile(string fileName, List<dynamic> sectionList) {

            if (sectionList == null)
            {
                sectionList = new List<dynamic>()
                {
                    new Header(Guid.NewGuid().ToString(), 1),
                    new Hero(Guid.NewGuid().ToString(), 2),
                    new ItemList(Guid.NewGuid().ToString(), 3),
                };
            }


            string SectionModelsJson = "";
            foreach (var section in sectionList)
            {
                SectionModelsJson += JsonConvert.SerializeObject(section);
                SectionModelsJson += "\n";
            }

            System.IO.File.WriteAllText($"dataModelDB/{fileName}.json", SectionModelsJson);

        }

    }

    
}
