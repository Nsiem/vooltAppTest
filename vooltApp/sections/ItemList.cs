using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace vooltApp.sections
{
    public class ItemList: Sections, ISerializable
    {
        public string ClassType { get; set; }
        public string Heading { get; set; }

        public List<Dictionary<string, dynamic>> Cards { get; set; }

        public Dictionary<string, dynamic> Button { get; set; }

        public ItemList(string Id, int OrderNum)
        {
            ClassType = "ItemList";
            Section_Id = Id;
            Order = OrderNum;
            Heading = "Our Services";
            Cards = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
                {
                    {"heading", "Logo Design" },
                    {"text", "We make logos" },
                    {"image", new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png") },
                    {"imageVisible", false }
                },

                new Dictionary<string, dynamic>()
                {
                    {"heading", "Website Design" },
                    {"text", "We design websites!" },
                    {"image", new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png") },
                    {"imageVisible", false }
                },

                new Dictionary<string, dynamic>()
                {
                    {"heading", "Graphic design" },
                    {"text", "We design the best graphics!" },
                    {"image", new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png") },
                    {"imageVisible", false }
                },
            };
            Button = new Dictionary<string, dynamic>() {
                {"text", "text for the button"},
                {"status", "status of display (as a string)"},
                {"logo", new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png")},
                {"Events", "events that occur (as a string)"}
            };

        }

        protected ItemList(SerializationInfo info, StreamingContext context)
        {
            ClassType = info.GetString("ClassType");
            Section_Id = info.GetString("Section_Id");
            Order = info.GetInt32("Order");
            Heading = info.GetString("Heading");
            Cards = (List<Dictionary<string, dynamic>>)info.GetValue("Button", typeof(List<Dictionary<string, dynamic>>));
            Button = (Dictionary<string, dynamic>)info.GetValue("Button", typeof(Dictionary<string, dynamic>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassType", ClassType);
            info.AddValue("Section_Id", Section_Id);
            info.AddValue("Order", Order);
            info.AddValue("Heading", Heading);
            info.AddValue("Cards", Cards);
            info.AddValue("Button", Button);
        }


    }
}
