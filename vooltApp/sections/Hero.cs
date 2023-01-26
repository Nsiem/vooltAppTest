namespace vooltApp.sections
{
    public class Hero
    {
        public string Section_Id { get; set; }

        public int Order { get; set; }

        public string Heading = "Brilliant Crafted Designs!";

        public string Text = "We make great designs!";

        public Dictionary<string, dynamic> Button = new Dictionary<string, dynamic>() {
            {"text", "text for the button"},
            {"status", "status of display (as a string)"},
            {"logo", new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png")},
            {"Events", "events that occur (as a string)"}
        };

        public Uri Image = new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png");

        public string ImageAlignment = "right";

        public string ContentAlignment = "left";
    }
}
