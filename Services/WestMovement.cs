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

            if (proposedWestMovement < (Math.Round((currentWestLocation - 51d) / 100d, 0) * 100) + 1)
            {
                perimeterReached = true;
                while (RoverLocation.RoverInstance.CurrentLocation > ((Math.Round(currentWestLocation / 100d, 0) * 100) + 1))
                {
                    RoverLocation.RoverInstance.CurrentLocation -= 1;
                }
                return RoverLocation.RoverInstance.CurrentLocation;
            }
            return RoverLocation.RoverInstance.CurrentLocation -= movementNumber;
        }
    }
}