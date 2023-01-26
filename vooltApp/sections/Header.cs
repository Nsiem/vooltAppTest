namespace vooltApp.sections
{
    public class Header
    {
        public string Section_Id { get; set; }

        public int Order { get; set; }

        public string Business_name = "My Business";

        public Uri Logo = new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png");

        public bool Logo_displayed = false;

        public Dictionary<string, dynamic> Menu = new Dictionary<string, dynamic>(){
            {"About US", new Uri("aboutUsLink.com")},
            { "Reviews", new Uri("reviewsLink.com")},
            { "Services", new Dictionary<string, dynamic>(){
                {"service1", new Uri("service1Link.com")},
                {"service2", new Uri("service2Link.com")}
                }
            } 
        };

        public Dictionary<string, dynamic> Button = new Dictionary<string, dynamic>() {
            {"text", "text for the button"},
            {"status", "status of display (as a string)"},
            {"logo", new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png")},
            {"Events", "events that occur (as a string)"}
        };
    }
}
