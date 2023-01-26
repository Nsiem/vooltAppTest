namespace vooltApp.sections
{
    public class Header
    {
        public string Section_Id { get; set; }

        public int Order { get; set; }

        public string Business_name { get; set; } = "My Business";

        public Uri Logo { get; set; } = new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png");

        public bool Logo_displayed { get; set; } = false;

        public Dictionary<string, dynamic> Menu { get; set; } = new Dictionary<string, dynamic>(){
            {"About US", new Uri("https://aboutUsLink.com")},
            { "Reviews", new Uri("https://reviewsLink.com")},
            { "Services", new Dictionary<string, dynamic>(){
                {"service1", new Uri("https://service1Link.com")},
                {"service2", new Uri("https://service2Link.com")}
                }
            } 
        };

        public Dictionary<string, dynamic> Button { get; set; } = new Dictionary<string, dynamic>() {
            {"text", "text for the button"},
            {"status", "status of display (as a string)"},
            {"logo", new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png")},
            {"Events", "events that occur (as a string)"}
        };
    }
}
