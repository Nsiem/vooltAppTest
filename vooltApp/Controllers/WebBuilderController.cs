using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using vooltApp.sections;

namespace vooltApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebBuilderController : ControllerBase
    {
        [HttpPost(Name = "CreateDataModel")]
        public IActionResult CreateDataModel([FromBody] string key)
        {
            List<dynamic> sectionModels = new List<dynamic>()
            {
                new Header(),
                new Hero(),
                new ItemList()
            };

            List<dynamic> sections = new List<dynamic>();

            int i = 1;
            foreach (dynamic section in sectionModels)
            {
                section.Section_Id = Guid.NewGuid().ToString();
                section.Order = i;
                i++;
                sections.Add(section);
            }

            System.IO.File.WriteAllText($"dataModelDB/{key}.json", JsonSerializer.Serialize(sections));

            return Ok($"Successfully created data model using key: {key}");
        }

        [HttpGet(Name = "GetDataModel")]
        public IActionResult GetDataModel(string key)
        {
            string JsonModel = System.IO.File.ReadAllText($"dataModelDB/{key}.json");
            List<dynamic> JsonDeserialized = JsonSerializer.Deserialize<List<dynamic>>(JsonModel);

            return Ok(JsonDeserialized);
        }

        [HttpPut(Name = "ChangeSection")]
        public IActionResult ChangeSection(string key, string section_Id, [FromBody] Dictionary<string, dynamic> section)
        {

            return Ok(section);
        }

    }
}
