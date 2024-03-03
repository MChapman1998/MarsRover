using MarsRover.Common;
using MarsRover.Interfaces;
using MarsRover.Models;
using System.Text.RegularExpressions;

namespace MarsRover.Services
{
    public class MovementService : IMovementService
    {
        private bool perimeterReached = false;

        public string HandleMovement(Commands commands)
        {
            foreach (var command in commands.commands)
            {
                if (Regex.IsMatch(command, Constants.MovementAmountRegex))
                {
                    RoverLocation.RoverInstance.CurrentLocation = ChangeLocation(command);
                }
                else
                {
                    RoverLocation.RoverInstance.CurrentDirection = ChangeDirection(command);
                }

                if(perimeterReached)
                {
                    break;
                }
            }

            return $"{RoverLocation.RoverInstance.CurrentLocation} {RoverLocation.RoverInstance.CurrentDirection}";
        }

        private string ChangeDirection(string newDirection)
        {
            switch (newDirection.ToLower())
            {
                case "left":
                    return Constants.LeftDirectionChange[RoverLocation.RoverInstance.CurrentDirection];
                case "right":
                    return Constants.RightDirectionChange[RoverLocation.RoverInstance.CurrentDirection];
                default:
                    return RoverLocation.RoverInstance.CurrentDirection;
            }
        }

        private int ChangeLocation(string movementAmount)
        {
            int movementNumber = int.Parse(movementAmount[..^1]);
            switch (RoverLocation.RoverInstance.CurrentDirection)
            {
                case "north":
                    int proposedNorthMovement = RoverLocation.RoverInstance.CurrentLocation - (100 * movementNumber);
                    if (proposedNorthMovement <= 0)
                    {
                        perimeterReached = true;
                        while(RoverLocation.RoverInstance.CurrentLocation > 100)
                        {
                            RoverLocation.RoverInstance.CurrentLocation -= 100;
                        }
                        return RoverLocation.RoverInstance.CurrentLocation;
                    }
                    return RoverLocation.RoverInstance.CurrentLocation - (100 * movementNumber);
                case "south":
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
                case "east":
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
                case "west":
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
                default:
                    return 0;
            }
        }
    }
}