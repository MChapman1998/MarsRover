using MarsRover.Common;
using MarsRover.Interfaces;
using MarsRover.Models;
using System.Text.RegularExpressions;

namespace MarsRover.Services
{
    public class MovementService : IMovementService
    {
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
            //edge cases will come into play here
            int movementNumber = int.Parse(movementAmount[..^1]);
            switch (RoverLocation.RoverInstance.CurrentDirection)
            {
                case "north":
                    return RoverLocation.RoverInstance.CurrentLocation - (100 * movementNumber);
                case "south":
                    return (100 * movementNumber) + RoverLocation.RoverInstance.CurrentLocation;
                case "east":
                    return RoverLocation.RoverInstance.CurrentLocation += movementNumber;
                case "west":
                    return RoverLocation.RoverInstance.CurrentLocation -= movementNumber;
                default:
                    return 0;
            }
        }
    }
}