using MarsRover.Interfaces;
using MarsRover.Models;

namespace MarsRover.Services
{
    public class NorthMovement : INorthMovement
    {
        public int MoveNorth(ref bool perimeterReached, int movementNumber)
        {
            int proposedNorthMovement = RoverLocation.RoverInstance.CurrentLocation - (100 * movementNumber);
            if (proposedNorthMovement <= 0)
            {
                perimeterReached = true;
                while (RoverLocation.RoverInstance.CurrentLocation > 100)
                {
                    RoverLocation.RoverInstance.CurrentLocation -= 100;
                }
                return RoverLocation.RoverInstance.CurrentLocation;
            }
            return RoverLocation.RoverInstance.CurrentLocation - (100 * movementNumber);
        }
    }
}