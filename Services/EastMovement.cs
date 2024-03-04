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
            int rightMostValue = (int)((currentEastLocation + 99d) / 100d) * 100;

            if (proposedEastMovement > rightMostValue)
            {
                perimeterReached = true;
                while (RoverLocation.RoverInstance.CurrentLocation < rightMostValue)
                {
                    RoverLocation.RoverInstance.CurrentLocation += 1;
                }
                return RoverLocation.RoverInstance.CurrentLocation;
            }

            return RoverLocation.RoverInstance.CurrentLocation += movementNumber;
        }
    }
}