using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using vooltApp.sections;

namespace vooltApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebBuilderController : ControllerBase
    {
        /*
         * The POST endpoint for generating a json file. 
         */
        [HttpPost(Name = "CreateDataModel")]
        public IActionResult CreateDataModel(string key)
        {
            List<dynamic> sectionModels = new List<dynamic>()
            {
                new Header(Guid.NewGuid().ToString(), 1),
                new Hero(Guid.NewGuid().ToString(), 2),
                new ItemList(Guid.NewGuid().ToString(), 3),
            };
            string SectionModelsJson = "";
            foreach(var section in sectionModels)
            {
                SectionModelsJson += JsonConvert.SerializeObject(section);
                SectionModelsJson += "\n";
            }

            System.IO.File.WriteAllText($"dataModelDB/{key}.json", SectionModelsJson);
            return Ok($"Successfully created data model using key: {key}");
        }

        
        /*The GET endpoint for getting the json file*/

        [HttpGet(Name = "GetDataModel")]
        public IActionResult GetDataModel(string key)
        {
            string[] JsonStringLines = System.IO.File.ReadAllLines($"dataModelDB/{key}.json");
            List<string> JsonStrings = new List<string>();
            JsonStrings.AddRange(JsonStringLines);

            List<dynamic> sectionModels = new List<dynamic>();
            foreach (string JsonString in JsonStrings)
            {
                JObject json = JObject.Parse(JsonString);
                string ClassType = json["ClassType"].Value<string>();
                switch(ClassType)
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

            return Ok(sectionModels);
        }

        /*
         * The PUT endpoint for updating the sections in the file
         *//*
        [HttpPut(Name = "ChangeSection")]
        public IActionResult ChangeSection(string key, string section_Id, [FromBody] Dictionary<string, dynamic> section)
        {
            string JsonModel = System.IO.File.ReadAllText($"dataModelDB/{key}.json");
            
            List<dynamic> JsonDeserialized = JsonSerializer.Deserialize<List<dynamic>>(JsonModel);
            
            int index = 0;
            foreach(var ModelSection in JsonDeserialized)
            {
                return Ok(ModelSection["Section_Id"]);
                if (ModelSection["Section_Id"])
                {
                    JsonDeserialized[index] = section;
                    break;
                }
                index++;
            }
            
            System.IO.File.WriteAllText($"dataModelDB/{key}.json", JsonSerializer.Serialize(JsonDeserialized));
            //$"updated section_Id: {section_Id} in {key}.json"
            return Ok(JsonDeserialized);
        }*/

    }
}
