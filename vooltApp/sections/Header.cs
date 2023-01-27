using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace vooltApp.sections
{
    [Serializable]
    public class Header: Sections, ISerializable
    {
        public string ClassType { get; set; }
        public string Business_name { get; set; }

        public Uri Logo { get; set; }

        public bool Logo_displayed { get; set; }

        public Dictionary<string, dynamic> Menu { get; set; }

        public Dictionary<string, dynamic> Button { get; set; }

        public Header(string Id, int OrderNum)
        {
            ClassType = "Header";
            Section_Id = Id;
            Order = OrderNum;
            Business_name = "My Business";
            Logo = new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png");
            Logo_displayed = false;
            Menu = new Dictionary<string, dynamic>(){
                {"About US", new Uri("https://aboutUsLink.com")},
                { "Reviews", new Uri("https://reviewsLink.com")},
                { "Services","service1: https://service1Link.com, service2: https://service2Link.com"}
            };
            Button = new Dictionary<string, dynamic>() {
                {"text", "text for the button"},
                {"status", "status of display (as a string)"},
                {"logo", new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png")},
                {"Events", "events that occur (as a string)"}
            };
        }

        protected Header(SerializationInfo info, StreamingContext context)
        {
            ClassType = info.GetString("ClassType");
            Section_Id = info.GetString("Section_Id");
            Order = info.GetInt32("Order");
            Business_name = info.GetString("Business_name");
            Logo = (Uri)info.GetValue("Logo", typeof(Uri));
            Logo_displayed = info.GetBoolean("Logo_displayed");
            Menu = (Dictionary<string, dynamic>)info.GetValue("Menu", typeof(Dictionary<string, dynamic>));
            Button = (Dictionary<string, dynamic>)info.GetValue("Button", typeof(Dictionary<string, dynamic>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassType", ClassType);
            info.AddValue("Section_Id", Section_Id);
            info.AddValue("Order", Order);
            info.AddValue("Business_name", Business_name);
            info.AddValue("Logo", Logo);
            info.AddValue("Logo_displayed", Logo_displayed);
            info.AddValue("Menu", Menu);
            info.AddValue("Button", Button);
        }

        public void ConvertDictionary(JObject dict)
        {
            //Header ConvertedHeader = new Header(dict["section_Id"], dict["order"]);
/*            ClassType = dict["classType"];
            Business_name = dict["business_name"];
            Logo = dict["logo"];
            Logo_displayed = dict["logo_displayed"];
            Menu = dict["menu"];
            Button = dict["button"];*/

            //return ConvertedHeader;
        }
    }
}
