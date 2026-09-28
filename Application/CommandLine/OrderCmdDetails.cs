using PowerArgs;

namespace Application.CommandLine
{
    public class OrderCmdDetails
    {
        [
            ArgRequired(PromptIfMissing = true),
            ArgShortcut("p"),
            ArgDescription("Part of the day which defines the menu"),
            ArgExample("morning or evening", "Part of the day which defines available dishes"),
            ArgPosition(1)
        ]
        public string PartOfTheDay { get; set; }

        [
            ArgRequired(PromptIfMissing = true),
            ArgShortcut("o"),
            ArgDescription("A comma delimited list of Dishes"),
            ArgExample("1, 2, 3", "Dishes ids"),
            ArgPosition(2)
        ]
        public string Order { get; set; }
    }
}
