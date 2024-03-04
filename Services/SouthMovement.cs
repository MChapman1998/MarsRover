using MarsRover.Interfaces;
using MarsRover.Models;

namespace MarsRover.Services
{
    public class SouthMovement : ISouthMovement
    {
        public int MoveSouth(ref bool perimeterReached, int movementNumber)
        {
            int proposedSouthMovement = (100 * movementNumber) + RoverLocation.RoverInstance.CurrentLocation;
            if (proposedSouthMovement > 10000)
            {
                perimeterReached = true;
                while (RoverLocation.RoverInstance.CurrentLocation < 9000)
                {
                    RoverLocation.RoverInstance.CurrentLocation += 100;
                }
                return RoverLocation.RoverInstance.CurrentLocation;
            }
            return (100 * movementNumber) + RoverLocation.RoverInstance.CurrentLocation;
        }
    }
}