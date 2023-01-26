namespace vooltApp.sections
{
    public class ItemList
    {
        public string Section_Id { get; set; }

        public int Order { get; set; }

        public string Heading { get; set; } = "Our Services";

        public List<Dictionary<string, dynamic>> Cards { get; set; } = new List<Dictionary<string, dynamic>>()
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

        public Dictionary<string, dynamic> Button { get; set; } = new Dictionary<string, dynamic>() {
            {"text", "text for the button"},
            {"status", "status of display (as a string)"},
            {"logo", new Uri("https://cdn.pixabay.com/photo/2016/11/22/11/48/mountain-1849091_960_720.png")},
            {"Events", "events that occur (as a string)"}
        };

    }
}
