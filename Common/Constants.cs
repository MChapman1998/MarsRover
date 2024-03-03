namespace MarsRover.Common
{
    public static class Constants
    {
        public static readonly List<string> Directions = new List<string> { "left", "right", "up", "down" };
        public static readonly string MovementAmountRegex = "[0-9]{1,}[m]{1}";
        public static readonly Dictionary<string, string> LeftDirectionChange = new Dictionary<string, string>
        {
            { "north", "west" },
            { "east", "north" },
            { "south", "east" },
            { "west", "south" },
        };
        public static readonly Dictionary<string, string> RightDirectionChange = new Dictionary<string, string>
        {
            { "north", "east" },
            { "east", "south" },
            { "south", "west" },
            { "west", "north" },
        };
    }
}