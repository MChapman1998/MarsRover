using MarsRover.Interfaces;
using MarsRover.Models;

namespace MarsRover.Services
{
    public class WestMovement : IWestMovement
    {
        public int MoveWest(ref bool perimeterReached, int movementNumber)
        {
            int proposedWestMovement = RoverLocation.RoverInstance.CurrentLocation - movementNumber;
            double currentWestLocation = RoverLocation.RoverInstance.CurrentLocation;
            int leftMostRowValue = (int)((currentWestLocation - 1d) / 100d) * 100 + 1;

            if (proposedWestMovement < leftMostRowValue)
            {
                perimeterReached = true;
                while (RoverLocation.RoverInstance.CurrentLocation > leftMostRowValue)
                {
                    RoverLocation.RoverInstance.CurrentLocation -= 1;
                }
                return RoverLocation.RoverInstance.CurrentLocation;
            }
            return RoverLocation.RoverInstance.CurrentLocation -= movementNumber;
        }
    }
}