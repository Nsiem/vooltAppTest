using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using vooltApp.sections;

namespace vooltApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebBuilderController : ControllerBase
    {
        
        // The POST endpoint for generating a json file. 
         
        [HttpPost(Name = "CreateDataModel")]
        public IActionResult CreateDataModel(string key)
        {
            Sections.SerializeAndWriteToFile(key, null);

            return Ok($"Successfully created data model using key: {key}");
        }

        
        // The GET endpoint for getting the json file
        [HttpGet(Name = "GetDataModel")]
        public IActionResult GetDataModel(string key)
        {
            string[] JsonStringLines = System.IO.File.ReadAllLines($"dataModelDB/{key}.json");
            List<string> JsonStrings = new List<string>();
            JsonStrings.AddRange(JsonStringLines);

            List<dynamic> sectionModels = Sections.DeserializeSections(JsonStrings);

            return Ok(sectionModels);
        }

        
        //The PUT endpoint for updating the sections in the file

        [HttpPut(Name = "ChangeSection")]
        public IActionResult ChangeSection(string key, string section_Id, [FromBody] Dictionary<string, dynamic> sectionDumb)
        {
            
            //return Ok($"{section["classType"]} / {section["section_Id"]}, {section["order"]}, {section["business_name"]}, {section["menu"]}");
            // THIS BLOCK DESERIALIZES
            string[] JsonStringLines = System.IO.File.ReadAllLines($"dataModelDB/{key}.json");
            List<string> JsonStrings = new List<string>();
            JsonStrings.AddRange(JsonStringLines);

            List<dynamic> sectionModels = Sections.DeserializeSections(JsonStrings);
            /*
             *
                        string section = JsonConvert.SerializeObject(sectionDumb);
                        JObject jsonsection = JObject.Parse(section);
                        //FINDS AND REPLACES SECTION
                        int index = 0;
                        foreach (var Model in sectionModels)
                        {
                            if (Model.Section_Id == section_Id)
                            {
                                switch (Model.ClassType)
                                {
                                    case "Header":
                                        Header JsonHeader = new Header(jsonsection["section_Id"].Value<string>(), jsonsection["order"].Value<int>());
                                        JsonHeader.ConvertDictionary(jsonsection);
                                        sectionModels[index] = JsonHeader;
                                        break;
                                    case "Hero":
                                        Hero JsonHero = JsonConvert.DeserializeObject<Hero>(section);
                                        sectionModels[index] = JsonHero;
                                        break;
                                    case "ItemList":
                                        ItemList JsonItemList = JsonConvert.DeserializeObject<ItemList>(section);
                                        sectionModels[index] = JsonItemList;
                                        break;
                                }
                            }
                            index++;
                        }*/

            Sections.SerializeAndWriteToFile(key, sectionModels);

            return Ok($"updated section_Id: {section_Id} in {key}.json");
        }

        [HttpDelete(Name = "DeleteSection")]
        public IActionResult DeleteSection(string key, string section_Id)
        {
            string[] JsonStringLines = System.IO.File.ReadAllLines($"dataModelDB/{key}.json");
            List<string> JsonStrings = new List<string>();
            JsonStrings.AddRange(JsonStringLines);

            List<dynamic> sectionModels = Sections.DeserializeSections(JsonStrings);

            //FINDS AND DELETE SECTION
            int index = 0;
            foreach (var Model in sectionModels)
            {
                if (Model.Section_Id == section_Id)
                {
                    sectionModels.RemoveAt(index);
                    break;
                }
                index++;
            }

            Sections.SerializeAndWriteToFile(key, sectionModels);

            return Ok($"Deleted section from file: {key}");


        }

    }
}
