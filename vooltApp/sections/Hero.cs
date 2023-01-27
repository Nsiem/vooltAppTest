using System.Runtime.Serialization;

namespace vooltApp.sections
{
    public class Hero: Sections, ISerializable
    {
        public string ClassType { get; set; }
        public string Heading { get; set; } 

        public string Text { get; set; }

        public Dictionary<string, dynamic> Button { get; set; }

        public Uri Image { get; set; }

        public string ImageAlignment { get; set; }

        public string ContentAlignment { get; set; }

        public Hero(string Id, int OrderNum)
        {
            ClassType = "Hero";
            Section_Id = Id;
            Order = OrderNum;
            Heading = "Brilliant Crafted Designs!";
            Text = "We make great designs!";
            Button = new Dictionary<string, dynamic>() {
                {"text", "text for the button"},
                {"status", "status of display (as a string)"},
                {"logo", new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png")},
                {"Events", "events that occur (as a string)"}
            };
            Image = new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png");
            ImageAlignment = "right";
            ContentAlignment = "left";
        }

        protected Hero(SerializationInfo info, StreamingContext context)
        {
            ClassType = info.GetString("ClassType");
            Section_Id = info.GetString("Section_Id");
            Order = info.GetInt32("Order");
            Heading = info.GetString("Heading");
            Text = info.GetString("Text");
            Image = (Uri)info.GetValue("Image", typeof(Uri));
            Button = (Dictionary<string, dynamic>)info.GetValue("Button", typeof(Dictionary<string, dynamic>));
            ImageAlignment = info.GetString("ImageAlignment");
            ContentAlignment = info.GetString("ContentAlignment");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassType", ClassType);
            info.AddValue("Section_Id", Section_Id);
            info.AddValue("Order", Order);
            info.AddValue("Heading", Heading);
            info.AddValue("Text", Text);
            info.AddValue("Image", Image);
            info.AddValue("Button", Button);
            info.AddValue("ImageAlignment", ImageAlignment);
            info.AddValue("ContentAlignment", ContentAlignment);
        }

        public static Hero ConvertDictionary(Dictionary<string, dynamic> dict)
        {
            Hero ConvertedHero = new Hero(dict["section_Id"], dict["order"]);
            ConvertedHero.ClassType = dict["classType"];
            ConvertedHero.Heading = dict["heading"];
            ConvertedHero.Text = dict["text"];
            ConvertedHero.Image = dict["image"];
            ConvertedHero.ImageAlignment = dict["imageAlignment"];
            ConvertedHero.ContentAlignment = dict["contentAlignment"];
            ConvertedHero.Button = dict["button"];

            return ConvertedHero;
        }
    }
}
