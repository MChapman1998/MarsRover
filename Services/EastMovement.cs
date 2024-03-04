using MarsRover.Interfaces;
using MarsRover.Models;

namespace MarsRover.Services
{
    public class EastMovement : IEastMovement
    {
        public int MoveEast(ref bool perimeterReached, int movementNumber)
        {
            int proposedEastMovement = RoverLocation.RoverInstance.CurrentLocation + movementNumber;
            double currentEastLocation = RoverLocation.RoverInstance.CurrentLocation;

            if (proposedEastMovement > (Math.Round((currentEastLocation + 50d) / 100d, 0) * 100))
            {
                perimeterReached = true;
                while (RoverLocation.RoverInstance.CurrentLocation < (Math.Round(currentEastLocation / 100d, 0) * 100) + 100)
                {
                    RoverLocation.RoverInstance.CurrentLocation += 1;
                }
                return RoverLocation.RoverInstance.CurrentLocation;
            }

            return RoverLocation.RoverInstance.CurrentLocation += movementNumber;
        }
    }
}