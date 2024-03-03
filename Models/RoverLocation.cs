using System.Diagnostics.CodeAnalysis;

namespace MarsRover.Models
{
    [ExcludeFromCodeCoverage]
    public class RoverLocation
    {
        private static RoverLocation? _roverInstance = null;

        private RoverLocation() { }

        public static RoverLocation? RoverInstance
        {
            get
            {
                if (_roverInstance == null)
                {
                    _roverInstance = new RoverLocation();
                }
                return _roverInstance;
            }
        }


        public int CurrentLocation { get; set; } = 1;
        public string? CurrentDirection { get; set; } = "south";

    }
}